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

        <new-product-modal 
            v-if="isNewProductVisible" 
            @save:product="saveNewProduct"
            @close="closeModals"
        />

        <shipment-modal
      v-if="isShipmentVisible"
      :inventory="inventory"
      @save:shipment="saveNewShipment"
      @close="closeModals"
    />
    </div>
</template>

<script lang="ts">
import { Options, Vue } from "vue-class-component";
import { IProduct, IProductInventory } from "@/types/Product";
import SolarButton from "@/components/SolarButton.vue";
import NewProductModal from "@/components/modals/NewProductModal.vue";
import ShipmentModal from "@/components/modals/ShipmentModal.vue";
import { IShipment } from "@/types/Shipment";
@Options({
    name: "Inventory",
  components: { SolarButton, NewProductModal, ShipmentModal },
})
export default class Inventory extends Vue {
    isNewProductVisible = false;
    isShipmentVisible = false;
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

    closeModals() {
        this.isShipmentVisible = false;
        this.isNewProductVisible = false;
    }

    showNewProductModal() {
        this.isNewProductVisible = true;
    }

    showShipMentModal() {
        this.isShipmentVisible = true;
    }

    saveNewProduct(newProduct: IProduct) {
        console.log("SaveNewProduct");
        console.log(newProduct);
        
        
    }

    saveNewShipment(shipment: IShipment) {
        console.log('saveNewShipment:');
        console.log(shipment);
    }

    
}
</script>
