<template>
    <solar-modal>
        
    </solar-modal>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import SolarButton from "@/components/SolarButton.vue";
import SolarModal from "@/components/modals/SolarModal.vue";
@Options({
  components: {
    SolarButton,
    SolarModal
  },
})

export default class ShipmentModal extends Vue {}
</script>
