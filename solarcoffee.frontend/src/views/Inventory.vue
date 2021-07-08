<template>
    <div class="inventory-container">
        <h1 id="InventoryTitle">
        Inventory Dashboard
        </h1>
        <hr />

        <div class="inventory-actions">
            <solar-button @click.native="showNewProductModal" id="addNewBtn">
                Add New Item
            </solar-button>
            <solar-button @click.native="showShipMentModal" id="recieveShipmentBtn">
                Recieve Shipment
            </solar-button>
        </div>
        <table id="inventoryTable" class="table">
            <tr>
                <th>Item</th>
                <th>Quantity On-hand</th>
                <th>Unit Price</th>
                <th>Taxable</th>
                <th>Delete</th>
            </tr>

            <tr v-for="item in inventory">
                <td>
                    {{ item.product.name }}
                </td>
                <td>
                    {{ item.quantityOnHand }}
                </td>
                <td>
                    {{ item.product.price | price }}
                </td>
                <td>
                    <span v-if="item.product.isTaxable">
                        Yes
                    </span>
                    <span v-else>
                        No
                    </span>
                </td>
                <td>
                    <div>
                        X
                    </div>
                </td>
            </tr>
        </table>
        <new-product-modal v-if="isNewProductVisible" />
        <shipment-modal v-if="isShipmentVisible" />
    </div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import { IProductInventory } from "@/types/Product";
import SolarButton from "@/components/SolarButton.vue";

@Options({
    name: "Inventory",
  components: { SolarButton },
})
export default class Inventory extends Vue {
    isNewProductVisible: boolean = false;
    isShipmentVisible: boolean = false;
    inventory: IProductInventory[] = [
        {
            id: 1,
            product: {
                id: 1,
                name: "Some Product",
                description: "Good Stuff",
                price: 100,
                createdOn: new Date(),
                updatedOn: new Date(),
                isTaxable: true,
                isArchived: false
            },
            quantityOnHand: 100,
            idealQuantity: 100
        },
        {
            id: 2,
            product: {
                id: 2,
                name: "Another Product",
                description: "Good Stuff",
                price: 100,
                createdOn: new Date(),
                updatedOn: new Date(),
                isTaxable: false,
                isArchived: false
            },
            quantityOnHand: 40,
            idealQuantity: 50
        }
    ];

    showNewProductModal() {

    }

    showShipMentModal() {
        
    }
}
</script>
