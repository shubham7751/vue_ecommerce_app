import { createStore } from 'vuex';
import products from './modules/products';

export default createStore({
    state: {
        cart: [],
        cartTotal: 0,
        likedProducts: JSON.parse(localStorage.getItem('likedProducts')) || []
    },
    mutations: {
        initialiseStore(state) {
            if (localStorage.getItem('cart')) {
                state.cart = JSON.parse(localStorage.getItem('cart'));
            }
            if (localStorage.getItem('cartTotal')) {
                state.cartTotal = parseFloat(localStorage.getItem('cartTotal'));
            }
        },
        addRemoveCart(state, payload) {
            if (payload.toAdd) {
                state.cart.push(payload.product);
            } else {
                state.cart = state.cart.filter(obj => obj.productID !== payload.product.productID);
            }
            state.cartTotal = state.cart.reduce((accumulator, object) => {
                return parseFloat(accumulator) + parseFloat(object.price * object.qty);
            }, 0);
            localStorage.setItem('cartTotal', JSON.stringify(state.cartTotal));
            localStorage.setItem('cart', JSON.stringify(state.cart));
        },
        updateCart(state, payload) {
            state.cart.find(o => o.productID === payload.product.productID).qty = payload.product.qty;
            state.cartTotal = state.cart.reduce((accumulator, object) => {
                return parseFloat(accumulator) + parseFloat(object.price * object.qty);
            }, 0);
            localStorage.setItem('cartTotal', JSON.stringify(state.cartTotal));
            localStorage.setItem('cart', JSON.stringify(state.cart));
        },
        toggleLikeProduct(state, product) {
            const index = state.likedProducts.findIndex(p => p.productID === product.productID);
            if (index === -1) {
                state.likedProducts.push(product);
            } else {
                state.likedProducts.splice(index, 1);
            }
            localStorage.setItem('likedProducts', JSON.stringify(state.likedProducts));
        }
    },
    getters: {
        isProductLiked: (state) => (product) => {
            return state.likedProducts.some(p => p.productID === product.productID);
        },
        likedProducts(state) {
            return state.likedProducts;
        }
    },
    actions: {},
    modules: {
        products
    }
});
