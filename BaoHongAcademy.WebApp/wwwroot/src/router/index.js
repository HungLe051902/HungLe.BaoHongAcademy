import { createWebHistory, createRouter } from "vue-router";
import { routes } from "./routes";
import { TOKEN_KEY } from "@/helpers/authenticationHelper.js";

const router = createRouter({
  history: createWebHistory(),
  routes,
});

/**
 * Global Before Guards
 */
/* eslint-disable no-alert, no-console */
router.beforeEach((to, from, next) => {
  var token = localStorage.getItem(TOKEN_KEY);
  if (!token) {
    var listRouteNotAuthorize = ["/", "/login", "/register"];
    if (listRouteNotAuthorize.includes(to.path)) {
      next();
    } else {
      next({ name: "LandingPage" });
    }
  } else {
    if (["/login", "/register"].includes(to.path)) {
      next({ name: "Main" });
    } else {
      next();
    }
  }
});
/* eslint-enable no-alert */
export default router;
