<template>
    <div>
        <!-- Button to trigger modal -->
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#addProductModal">
            Add Product
        </button>

        <!-- Modal -->
        <div class="modal" id="addProductModal" tabindex="-1" aria-labelledby="addProductModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="addProductModalLabel">Add Product</h5>
                        
                        <button type="button" class="close" style="
    color: red;
    border: none;
" data-dismiss="modal" aria-label="Close" >
                            <i class="bi bi-x-lg"></i> 
                        </button>
                    </div>
                    <div class="modal-body">
                        <form @submit.prevent="submitForm">
                            <div class="form-group">
                                <label for="name">Name:</label>
                                <input type="text" v-model="product.name" class="form-control" id="name" required>
                            </div>
                            <div class="form-group">
                                <label for="brand">Brand:</label>
                                <input type="text" v-model="product.brand" class="form-control" id="brand" required>
                            </div>
                            <div class="form-group">
                                <label for="description">Description:</label>
                                <textarea v-model="product.description" class="form-control" id="description" required></textarea>
                            </div>
                            <div class="form-group">
                                <label for="price">Price:</label>
                                <input type="number" v-model="product.price" class="form-control" id="price" required>
                            </div>
                            <div class="form-group">
                            <label for="imageUrl">Image URL:</label>
                            <input type="url" v-model="product.imageURL" class="form-control" id="imageUrl" required>
                            </div>

                            <hr />
                            <button type="submit" class="btn btn-primary">Add Product</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>

        <!-- Display the latest added product details -->
        <div v-if="latestProduct" class="mt-4">
            </div>
    </div>
</template>

<script>
    import { mapActions, mapGetters } from 'vuex';

    export default {
        data() {
            return {
                product: {
                    name: '',
                    brand: '',
                    description: '',
                    price: 0,
                    imageURL:''
                },
            };
        },
        computed: {
            ...mapGetters({
                products: 'products',
            }),
            latestProduct() {
                return this.products.length ? this.products[this.products.length - 1] : null;
            },
        },
        methods: {
            ...mapActions(['addProduct']),
            submitForm() {
                this.addProduct(this.product);
                this.product.name = '';
                this.product.brand = '';
                this.product.description = '';
                this.product.price = 0;
                this.product.imageURL = 0;
                // Close the modal programmatically
                //$('#addProductModal').modal('hide');
            },
        },
    };
</script>

<style scoped>
    .product-name {
        font-size: 1.5em;
        font-weight: bold;
    }

    .product-brand, .product-description, .product-price {
        margin-top: 0.5em;
    }




    
    .modal {
        display: none;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.4);
        justify-content: center;
        align-items: center;
    }

    .modal-content {
        background-color: #fefefe;
        margin: 15px auto;
        padding: 10px;
        border: 1px solid #888;
        width: 500px;
        height: 500px;
    }

    .modal-close {
        border: none;
        color: red;
        position: absolute;
        right: 20px;
        top: 10px;
    }
</style>
