import { createApp } from 'vue';
import ApiPlugin from "./plugins/api";
import App from './App.vue';

import { createRouter, createWebHistory } from "vue-router";

import VendingMachine from './components/VendingMachine.vue';

const router = createRouter({
  history: createWebHistory(),

  routes: [
    { path: "/", name: VendingMachine, component: VendingMachine},
  ],
});

const app = createApp(App);
app.use(router);
app.use(ApiPlugin);
app.mount("#app");
