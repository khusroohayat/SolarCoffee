<template>
    <div class="side-menu-container">
        <img alt="Solar Coffee logo" src="../assets/images/solar_coffee_logo.png" />
    </div>
</template>

<script lang="ts">
import { Vue } from 'vue-class-component'

export default class SideMenu extends Vue { }
</script>

<style lang="scss" scoped>
    @import "@/scss/global.scss";

    .side-menu-container {
        background-color: #fcfcfc;
        height: 100vh;
        width: $menu-width;
        display: flex;
        flex-direction: column;
        padding: 0.8rem;
        box-shadow: 0 1px 1px rgba(0, 0, 0, 0.12), 0 1px 1px rgba(0, 0, 0, 0.24);
        box-sizing: border-box;
    }
</style>