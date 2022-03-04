import { createWebHistory, createRouter } from "vue-router";
import { routes } from "./routes";
import { getToken } from "@/helpers/authenticationHelper.js";

const router = createRouter({
  history: createWebHistory(),
  routes,
});

/**
 * Global Before Guards
 */
/* eslint-disable no-alert, no-console */
router.beforeEach((to, from, next) => {
  var token = getToken();
  if (!token) {
    var listRouteNotAuthorize = ["/", "/login", "/register"];
    if (listRouteNotAuthorize.includes(to.path)) {
      next();
    } else {
      next({ name: "LandingPage" });
    }
  }

  next();
});
/* eslint-enable no-alert */
export default router;
