

import { createRouter, createWebHistory } from 'vue-router';
import SignUp from '@/views/SignUp.vue';
import About from '@/views/About.vue';
import ContactUs from '@/views/ContactUs.vue';
import Login from '@/views/Login.vue';
import Cart from '@/views/Cart.vue';
import AllProductList from '@/components/AllProductList.vue';
import AddProductsModal from '@/components/AddProductsModal.vue';
import LikedProducts from '@/components/LikedProducts.vue';
import Home from '/src/views/Home.vue'
import DefaultLayout from '/src/Layout/DefaultLayout.vue'
const routes = [
    {
        path:'/',
        name:'Public',
        component:DefaultLayout,
        redirect: '/',
        children:[
            {
                path: '/signup',
                name: 'SignUp',
                component: SignUp,
               
            },  
            {
                path:'/cart',
                name:'Cart',
                component:Cart,
            },{
                path:'/likedproducts',
                name:'LikedProducts',
                component: LikedProducts,
            },
            {
                path: '/about',
                name: 'About',
                component: About,
    
            },
            {
                path: '/contactus',
                name: 'ContactUs',
                component: ContactUs,
    
            },
            {
                path: '/login',
                name: 'Login',
                component: Login,
    
            },
            {
                path: '/allProduct',
                name: 'AllProductList',
                component: AllProductList,
                
            },
            {
                path:'/',
                name:'Home',
                component:Home
            },
            {
                path: '/AddProductsModal',
                name: 'AddProductsModal',
                component: AddProductsModal,
               
            },
        ]
    },
]   
const router = createRouter({
    history: createWebHistory(),
    routes,
})
export default router