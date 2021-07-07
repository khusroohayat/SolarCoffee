<template>
  <div id="app">
    <div class="app-menu">
      <SideMenu />
    </div>
    <div class="app-content">
      <router-view /> 
    </div>
    
  </div>
  
</template>

<script lang="ts">
 
import { Options, Vue } from "vue-class-component";
import SideMenu from "./components/SideMenu.vue";

@Options({
  components: {
    SideMenu,
  },
})
export default class App extends Vue {}
</script>


<style lang="scss">
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #2c3e50;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>

function Component(arg0: { name: string; components: { SideMenu: any; }; }) {
  throw new Error("Function not implemented.");
}
