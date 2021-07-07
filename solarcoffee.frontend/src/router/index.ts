import { createRouter, createWebHistory, RouteRecordRaw } from "vue-router";
import Inventory from "@/views/Inventory.vue";
const routes: Array<RouteRecordRaw> = [
  {
    path: '/',
    name: 'home',
    component: Inventory
  },
  {
    path: '/inventory',
    name: 'inventory',
    component: Inventory
  }
];

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes,
});

export default router;
