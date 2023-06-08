import { RouteRecordRaw, createRouter, createWebHistory } from "vue-router";
import StudentList from "./StudentList.vue";
import StudentCreate from "./StudentCreate.vue";

export const routes: RouteRecordRaw[] = [
  {
    path: "/",
    name: "Home",
    component: StudentList,
  },
  {
    path: "/create-student",
    name: "CreateStudent",
    component: StudentCreate,
  },
];

export const router = createRouter({
  history: createWebHistory(),
  routes,
});
