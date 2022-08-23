//Vue instance
import { createApp } from 'vue'

//App component
import App from './App.vue'
import './assets/main.css'


//Bootstrap
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'

import {TablePlugin} from 'bootstrap-vue';

//Vue config
let app = createApp(App);
app.mount('#app');

app.use(BootstrapVue)
app.use(IconsPlugin)
app.use(TablePlugin)

// createApp(App).mount('#app')
