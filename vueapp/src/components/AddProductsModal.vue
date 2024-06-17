<template>
    <div>
        <!-- Stylish Add Product Button -->
        <button type="button" class="add-product-btn" @click="showModal = true">
            <i class="bi bi-plus-circle-fill"></i> 
        </button>

        <!-- Modal -->
        <div class="modal" v-if="showModal" @click.self="closeModal">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Add Product</h5>
                        <!-- Close Button with Right Side Alignment -->
                        <button type="button" class="btn-close" @click="closeModal" aria-label="Close">
                            <i class="bi bi-x-lg"></i>
                        </button>
                    </div>
                    <div class="modal-body">
                        <!-- Form for adding a product -->
                        <form @submit.prevent="submitForm">
                            <div class="form-group mb-3">
                                <label for="name">Name:</label>
                                <input type="text" v-model="product.name" class="form-control" id="name" required>
                            </div>
                            <div class="form-group mb-3">
                                <label for="brand">Brand:</label>
                                <input type="text" v-model="product.brand" class="form-control" id="brand" required>
                            </div>
                            <div class="form-group mb-3">
                                <label for="description">Description:</label>
                                <textarea v-model="product.description" class="form-control" id="description" required></textarea>
                            </div>
                            <div class="form-group mb-3">
                                <label for="price">Price:</label>
                                <input type="number" v-model="product.price" class="form-control" id="price" required>
                            </div>
                            <div class="form-group mb-3">
                                <label for="imageUrl">Image URL:</label>
                                <input type="url" v-model="product.imageURL" class="form-control" id="imageUrl" required>
                            </div>
                            <button type="submit" class="btn btn-primary w-100">Add Product</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        data() {
            return {
                showModal: false,
                product: {
                    name: '',
                    brand: '',
                    description: '',
                    price: 0,
                    imageURL: ''
                }
            };
        },
        methods: {
            submitForm() {
                axios.post('https://localhost:7018/api/product', this.product)
                    .then(response => {
                        console.log('Product added successfully:', response.data);
                        this.product = {
                            name: '',
                            brand: '',
                            description: '',
                            price: 0,
                            imageURL: ''
                        };
                        this.showModal = false; // Close modal after successful submission
                        // Optionally, show a success message or perform other actions
                    })
                    .catch(error => {
                        console.error('Error adding product:', error);
                        // Handle error scenarios, show messages, etc.
                    });
            },
            closeModal() {
                this.showModal = false; // Close modal when clicked outside or close button
            }
        }
    };
</script>

<style scoped>
    /* Stylish Add Product Button */
    .add-product-btn {
        display: inline-flex;
        align-items: center;
        background-color: #28a745; /* Green color */
        color: white;
        border: none;
        padding: 10px 20px;
        font-size: 1.2rem;
        border-radius: 30px; /* Rounded button */
        box-shadow: 0 4px 10px rgba(0, 0, 0, 0.2);
        transition: background-color 0.3s, transform 0.3s;
        cursor: pointer;
    }

        .add-product-btn:hover {
            background-color: #218838; /* Darker green on hover */
            transform: scale(1.05); /* Slightly enlarge on hover */
        }

        .add-product-btn i {
            margin-right: 10px; /* Space between icon and text */
        }

    /* Modal styling */
    .modal {
        display: flex;
        position: fixed;
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5);
        justify-content: center;
        align-items: center;
        z-index: 1050;
    }

    .modal-dialog {
        max-width: 500px;
        width: 100%;
    }

    .modal-content {
        background-color: #fff;
        border-radius: 8px;
        padding: 20px;
        position: relative;
    }

    .btn-close {
        background: none;
        border: none;
        font-size: 1.5rem;
        cursor: pointer;
        position: absolute;
        top: 10px;
        right: 10px;
    }

    .form-control {
        width: 100%;
        padding: 10px;
        margin-top: 5px;
    }

    .form-group {
        margin-bottom: 15px;
    }

    button.btn-primary {
        width: 100%;
        padding: 10px;
        background-color: #007bff;
        border: none;
        color: white;
        border-radius: 4px;
        cursor: pointer;
        transition: background-color 0.3s;
    }

        button.btn-primary:hover {
            background-color: #0056b3;
        }
</style>
