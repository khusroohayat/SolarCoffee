<template>
    <div class="btn-link">
        <button @click="visitRoute" 
        :class="['solar-button', { 'full-width': isFullWidth }]">
            <slot></slot>
        </button>
    </div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";

@Options({
  name: 'SolarButton',
  components: {},
  props: {
    link: String,
    isFullWidth: Boolean
  },
})



export default class SolarButton extends Vue {
    
    link!: string;
    isFullWidth?: boolean;

    visitRoute() {
        console.log(this.link);
        
        this.$router.push(this.link);
    }
}
</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";
.solar-button {
  background: lighten($solar-blue, 10%);
  color: white;
  padding: 0.8rem;
  transition: background-color 0.5s;
  margin: 0.3rem 0.2rem;
  display: inline-block;
  cursor: pointer;
  font-size: 1rem;
  min-width: 100px;
  border: none;
  border-bottom: 2px solid darken($solar-blue, 20%);
  border-radius: 3px;
  &:hover {
    background: lighten($solar-blue, 20%);
    transition: background-color 0.5s;
  }
  &:disabled {
    background: lighten($solar-blue, 15%);
    border-bottom: 2px solid lighten($solar-blue, 20%);
  }
  &:active {
    background: $solar-yellow;
    border-bottom: 2px solid lighten($solar-yellow, 20%);
  }
}

.full-width {
    display: block;
    width: 100%;
}

</style>