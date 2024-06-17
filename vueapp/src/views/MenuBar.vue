<template>
    <nav class="navbar navbar-expand-lg bg-light navbar-light fixed-top p-0 shadow-bottom" style="margin-top: 90px;">
        <div class="container-fluid">
            <button class="navbar-toggler"
                    type="button"
                    data-bs-toggle="collapse"
                    data-bs-target="#navbarSupportedContent"
                    aria-controls="navbarSupportedContent"
                    aria-expanded="false"
                    aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle fw-bold"
                           href="#"
                           id="navbarDropdownAllPages"
                           role="button"
                           data-bs-toggle="dropdown"
                           aria-expanded="false"
                           style="font-size: 1.1rem;">
                            All Pages
                        </a>
                        <ul class="dropdown-menu" aria-labelledby="navbarDropdownAllPages">
                            <li><router-link class="dropdown-item" to="/login">Sign In</router-link></li>
                            <li><router-link class="dropdown-item" to="/register">Sign Up</router-link></li>
                            <li><hr class="dropdown-divider" /></li>
                            <li><router-link class="dropdown-item" to="/checkout">Checkout Page</router-link></li>
                            <li><router-link class="dropdown-item" to="/contact-us">Contact Us</router-link></li>
                            <li><router-link class="dropdown-item" to="/blog">Blog</router-link></li>
                            <li><router-link class="dropdown-item" to="/blog/detail">Blog Detail</router-link></li>
                            <li><hr class="dropdown-divider" /></li>
                            <li><router-link class="dropdown-item" to="/404">404 Page Not Found</router-link></li>
                            <li><router-link class="dropdown-item" to="/500">500 Internal Server Error</router-link></li>
                        </ul>
                    </li>
                    <li class="nav-item"><router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Fashion</router-link></li>
                    <li class="nav-item"><router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Supermarket</router-link></li>
                    <li class="nav-item"><router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Electronics</router-link></li>
                    <li class="nav-item"><router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Furniture</router-link></li>
                    <li class="nav-item"><router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Garden & Outdoors</router-link></li>
                    <li class="nav-item"><router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Jewellery</router-link></li>
                    <li class="nav-item"><router-link class="nav-link" to="/documentation" style="font-size: 1.1rem;">Documentation</router-link></li>
                    <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle fw-bold"
                           href="#"
                           id="navbarDropdownLanguage"
                           role="button"
                           data-bs-toggle="dropdown"
                           aria-expanded="false"
                           style="font-size: 1.1rem;">
                            Language
                        </a>
                        <ul class="dropdown-menu" aria-labelledby="navbarDropdownLanguage">
                            <li><button class="dropdown-item" @click="changeLanguage('en')">English</button></li>
                            <li><button class="dropdown-item" @click="changeLanguage('mr')">Marathi</button></li>
                            <li><button class="dropdown-item" @click="changeLanguage('hi')">Hindi</button></li>
                        </ul>
                    </li>
                    <li class="nav-item">
                        <button class="btn" style="background: none; border: none;" @click="openModal">
                            <i class="bi bi-plus-circle-fill"></i>
                        </button>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Modal for Adding Product -->
    <div class="modal" v-if="showModal" @click.self="closeModal">
        <div class="modal-dialog modal-dialog-centered">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title text-center">Add Product</h5>
                    <button type="button" class="btn-close" @click="closeModal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <form @submit.prevent="submitForm">
                        <div class="mb-3">
                            <label for="productName" class="form-label">Name:</label>
                            <input type="text" class="form-control" id="productName" v-model="product.name" required>
                        </div>
                        <div class="mb-3">
                            <label for="productBrand" class="form-label">Brand:</label>
                            <input type="text" class="form-control" id="productBrand" v-model="product.brand" required>
                        </div>
                        <div class="mb-3">
                            <label for="productDescription" class="form-label">Description:</label>
                            <textarea class="form-control" id="productDescription" v-model="product.description" required></textarea>
                        </div>
                        <div class="mb-3">
                            <label for="productPrice" class="form-label">Price:</label>
                            <input type="number" class="form-control" id="productPrice" v-model.number="product.price" required>
                        </div>
                        <div class="mb-3">
                            <label for="productImageURL" class="form-label">Image URL:</label>
                            <input type="url" class="form-control" id="productImageURL" v-model="product.imageURL" required>
                        </div>
                        <button type="submit" class="btn btn-primary w-100">Add Product</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';

    export default {
        name: 'MenuBar',
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
            openModal() {
                this.showModal = true;
            },
            closeModal() {
                this.showModal = false;
            },
            submitForm() {
                axios.post('https://localhost:7018/api/product', this.product)
                    .then(response => {
                        console.log('Product added successfully:', response.data);
                        // Reset form fields
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
            changeLanguage(lang) {
                console.log(`Language changed to: ${lang}`);
                // Implement language change logic here
            }
        }
    };
</script>

<style scoped>
    /* Modal Styles */
    .modal {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5); /* Semi-transparent black background */
        display: flex;
        justify-content: center;
        align-items: center;
        z-index: 1050; /* Higher than the default Bootstrap modal */
    }

    .modal-dialog {
        max-width: 500px; /* Adjust as needed */
        width: 100%;
    }

    .modal-content {
        position: relative;
        background-color: #fff;
        border-radius: 10px;
        box-shadow:grey;
    }
    .shadow-bottom {
        color: grey;
        box-shadow: 0px 2px 4px rgba(0, 0, 0, 0.1);
    }
    .modal-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 1rem;
        border-bottom: 1px solid #e9ecef; /* Light gray border */
    }

    .modal-title {
        font-size: 1.25rem;
        font-weight: bold;
    }

    .modal-body {
        padding: 1rem;
    }

    .modal-footer {
        padding: 1rem;
        border-top: 1px solid #e9ecef; /* Light gray border */
    }

    .btn-close {
        background-color: transparent;
        border: none;
        cursor: pointer;
    }

    /* Optional: Adjust navbar height and other styles as needed */
   
    </style>