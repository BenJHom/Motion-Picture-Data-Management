import * as Vue from 'vue'
import { createApp } from 'vue'
import App from './App.vue'

import BootstrapVue from 'bootstrap-vue/dist/bootstrap-vue.esm';
import 'bootstrap-vue/dist/bootstrap-vue.css';
import 'bootstrap/dist/css/bootstrap.css';

Vue.useCssModule(BootstrapVue)
Vue.createApp(App).mount('#app')

createApp(App).use(BootstrapVue).mount('#app')
