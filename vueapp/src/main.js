import { createApp } from 'vue';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.bundle.js';

import App from './App.vue';
import router from './router';
import store from './store';

import { createHead } from '@vueuse/head'
const head = createHead()
import 'vuestic-ui/dist/vuestic-ui.css';
const app = createApp(App);

// Install the router
app.use(router);
app.use(head);
// Install the store
app.use(store);
// Mount the app
app.mount('#app');
