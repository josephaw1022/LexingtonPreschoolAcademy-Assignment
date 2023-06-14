import { RouteRecordRaw, createRouter, createWebHistory } from "vue-router";
import StudentList from "./StudentList.vue";
import StudentCreate from "./StudentCreate.vue";

export const routes: RouteRecordRaw[] = [
  {
    path: "/",
    name: "Home",
    component: StudentList,
    meta: {
      title: "Lexington Preschool Academy - Home",
    },
  },
  {
    path: "/create-student",
    name: "CreateStudent",
    component: StudentCreate,
    meta: {
      title: "Lexington Preschool Academy - Create Student",
    },
  },
];

export const router = createRouter({
  history: createWebHistory(),
  routes,
});
