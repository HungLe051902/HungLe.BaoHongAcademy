import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import { IonicVue } from "@ionic/vue";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css";

/* Core CSS required for Ionic components to work properly */
import "@ionic/vue/css/core.css";

/* Basic CSS for apps built with Ionic */
import "@ionic/vue/css/normalize.css";
import "@ionic/vue/css/structure.css";
import "@ionic/vue/css/typography.css";

/* Optional CSS utils that can be commented out */
import "@ionic/vue/css/padding.css";
import "@ionic/vue/css/float-elements.css";
import "@ionic/vue/css/text-alignment.css";
import "@ionic/vue/css/text-transformation.css";
import "@ionic/vue/css/flex-utils.css";
import "@ionic/vue/css/display.css";

/* Import css */
import "@/assets/scss/main.scss";

/* Vue-toastification */
import Notifications from "@kyvg/vue3-notification";

/* Font Awesome */
import { library } from "@fortawesome/fontawesome-svg-core";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { fas } from "@fortawesome/free-solid-svg-icons";
library.add(fas);
// import { fab } from "@fortawesome/free-brands-svg-icons";
// library.add(fab);
// import { far } from "@fortawesome/free-regular-svg-icons";
// library.add(far);
import { dom } from "@fortawesome/fontawesome-svg-core";
dom.watch();

const app = createApp({
  extends: App,
});

app.use(router);
app.use(IonicVue);
app.use(Notifications);
app.component("font-awesome-icon", FontAwesomeIcon);

app.mount("#app");
