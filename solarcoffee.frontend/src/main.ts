import { createApp } from "vue";
import { Vue } from "vue-class-component";
import App from "./App.vue";
import router from "./router";
import store from "./store";

// createApp.filter('price', function (number:number) {
//     if (isNaN(number)) {
//         return '-';
//     }

//     return '$ ' + number.toFixed(2);
// });
createApp(App).use(store).use(router).mount("#app");
