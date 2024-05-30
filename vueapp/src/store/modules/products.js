const state = {
    products: []
}

const getters = {
    products: state => state.products,
    latestProduct: state => state.products[state.products.length - 1]
}

const actions = {
    addProduct({ commit }, product) {
        commit('ADD_PRODUCT', product);
    }
}

const mutations = {
    ADD_PRODUCT(state, product) {
        state.products.push(product);
    }
}

export default {
    state,
    getters,
    actions,
    mutations
}
