import Vue from "vue";
import Vuesax from 'vuesax';
import 'vuesax/dist/vuesax.css' //Vuesax styles
import 'material-icons/iconfont/material-icons.css';
import App from "./App.vue";
import "./registerServiceWorker";
import router from "./router";
import store from "./store";
import "bootstrap";
import "bootstrap/dist/css/bootstrap.min.css"
import "./registerServiceWorker";

Vue.config.productionTip = false;
Vue.use(Vuesax);

new Vue({
  router,
  store,
  render: h => h(App)
}).$mount("#app");
