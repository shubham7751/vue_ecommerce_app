<template>
    <div class="product-container" style="margin-top:130px">
     
        <div class="container min-h-content py-5 text-center" style="margin-bottom: 100px;">
            <!-- Pagination Controls -->
            <div class="pagination-controls" v-if="totalPages > 1">
                <button @click="prevPage" :disabled="currentPage === 1">
                    <i class="bi bi-chevron-left"></i>
                </button>
                <button @click="nextPage" :disabled="currentPage === totalPages">
                    <i class="bi bi-chevron-right"></i>
                </button>
            </div>

            <!-- Product List -->
            <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
                <div class="col" v-for="(product, index) in paginatedProducts" :key="index">
                    <div class="card shadow-sm">
                        <!-- Like Icon -->
                        <div class="like-icon">
                            <i class="bi bi-heart bi-heart-empty Likebtnicon"
                               @click="toggleLike(product)"
                               :class="{ 'bi-heart-fill': product.liked }"></i>
                        </div>
                        <!-- Floating Heart Animation Container -->
                        <div v-if="product.showFloatingHeart" class="floating-heart">
                            <i class="bi bi-heart-fill heart-animation"></i>
                            <p>{{ product.floatingMessage }}</p>
                        </div>
                        <!-- Product Image -->
                        <div class="product-image">
                            <img @click="showImageModal(product.imageURL)" :src="product.imageURL" :width="imgWidth" :height="imgHeight" alt="Image not available">
                        </div>
                        <div class="card-body">
                            <p class="card-text">{{ product.name }}</p><br />
                            <div class="d-flex justify-content-between align-items-center">
                                <div class="btn-group">
                                    <CartBTN :product="product" @addToCart="addToCart(product.productID)" />
                                </div>
                                <small class="text-muted">₹{{ product.price }}</small>
                            </div><br />
                            <!-- Edit and Delete Buttons -->
                            <div class="button-container">
                                <button @click="editProduct(product)" class="btn btn-sm btn-outline-secondary me-2">
                                    <i class="bi bi-pencil"></i>
                                </button>
                                <button @click="confirmDelete(product.productID)" class="btn btn-sm btn-outline-danger">
                                    <i class="bi bi-trash"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <!-- Edit Modal -->
        <div v-if="editModalActive" class="modal">
            <div class="modal-background" @click="closeEditModal"></div>
            <div class="modal-content">
                <form @submit.prevent="submitEdit" class="p-3">
                    <h2 class="modal-title text-center">Edit Product</h2><hr/>
                    <button class="modal-close" aria-label="close" @click="closeEditModal">
                        <i class="bi bi-x-lg"></i>
                    </button>
                    <!-- Form Fields for Editing Product -->
                    <div class="mb-3">
                        <label for="editName" class="form-label">Name:</label>
                        <input type="text" id="editName" v-model="UpdateProduct.name" class="form-control" required>
                    </div>
                    <div class="mb-3">
                        <label for="editBrand" class="form-label">Brand:</label>
                        <input type="text" id="editBrand" v-model="UpdateProduct.brand" class="form-control" required>
                    </div>
                    <div class="mb-3">
                        <label for="editDescription" class="form-label">Description:</label>
                        <textarea id="editDescription" v-model="UpdateProduct.description" class="form-control" required></textarea>
                    </div>
                    <div class="mb-3">
                        <label for="editPrice" class="form-label">Price:</label>
                        <input type="number" id="editPrice" v-model="UpdateProduct.price" class="form-control" required>
                    </div>
                    <div class="mb-3">
                        <label for="editImage" class="form-label">Image URL:</label>
                        <input type="text" id="editImage" v-model="UpdateProduct.imageURL" class="form-control" required>
                    </div>
                    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                        <button type="submit" class="btn btn-primary me-md-2">Save</button>
                        <button type="button" @click="closeEditModal" class="btn btn-secondary">Cancel</button>
                    </div>
                </form>
            </div>
        </div>

        <!-- Delete Confirmation Modal -->
      

        <div v-if="deleteModalActive" class="modal">
            <div class="modal-background" @click="closeDeleteModal"></div>
            <div class="modal-content delete-modal">
                <h2 class="mb-2 text-center">Confirm Deletion</h2>
                <hr style="color:black" />
                <p>Are you sure you want to delete this product?</p><br />
                <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                    <button @click="deleteProduct(confirmDeleteId)" class="btn btn-danger me-md-2">Delete</button>
                    <button @click="closeDeleteModal" class="btn btn-secondary">Cancel</button>
                </div>
            </div>
        </div>

        <!-- Image Preview Modal -->
        <div class="modal" v-if="showModal">
            <div class="modal-content">
                <img :src="previewImageURL" alt="Preview Image" class="image-preview">
                <button class="modal-close" aria-label="close" @click="closeImageModal">
                    <i class="bi bi-x-lg"></i>
                </button>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    import { mapActions } from 'vuex';
    import { toast } from 'vue3-toastify';
    import 'vue3-toastify/dist/index.css';
    import CartBTN from '../components/CartBTN.vue';

    export default {
        name: 'ProductList',
        components: {
            CartBTN
        },
        data() {
            return {
                //imgWidth: 250, // Set width for product images
                //imgHeight: 300, // Set width for product images
                products: [], // Array to hold products
                editModalActive: false, // Boolean to control the edit modal visibility
                deleteModalActive: false, // Boolean to control the delete confirmation modal visibility
                UpdateProduct: { // Object to hold product data for editing
                    productId: null,
                    name: '',
                    brand: '',
                    description: '',
                    price: 0,
                    imageURL: ''
                },
                confirmDeleteId: null, // ID of the product to be deleted
                currentPage: 1, // Current page for pagination
                productsPerPage: 6, // Number of products to display per page
                showSuccessModal: false, // Boolean to control success modal visibility (not used in current code)
                previewImageURL: '', // URL for image preview modal
                showModal: false, // Boolean to control the image preview modal visibility
            };
        },
        computed: {
            imgHeight() {
                return Math.round(this.imgWidth * 1); // Adjust height based on width
            },
            totalPages() {
                return Math.ceil(this.products.length / this.productsPerPage); // Calculate total pages for pagination
            },
            paginatedProducts() {
                const start = (this.currentPage - 1) * this.productsPerPage;
                const end = start + this.productsPerPage;
                return this.products.slice(start, end); // Get products for the current page
            }
        },
        created() {
            this.fetchProducts(); // Fetch products when the component is created
        },
        methods: {
            ...mapActions(['addProduct', 'updateProduct', 'deleteProduct']),

            // Fetch products from the server
            async fetchProducts() {
                try {
                    const response = await axios.get('https://localhost:7018/api/Product');
                    this.products = response.data.reverse(); // Store the fetched products
                } catch (error) {
                    console.error('Error fetching products:', error);
                }
            },

            // Open the edit modal with selected product data
            editProduct(product) {
                this.UpdateProduct = { ...product }; // Copy the product data
                this.UpdateProduct.productId = product.productID; // Ensure the product ID is set
                this.editModalActive = true; // Show the edit modal
            },

            // Close the edit modal
            closeEditModal() {
                this.editModalActive = false; // Hide the edit modal
            },

            // Submit edited product data to the server

            // Submit edited product data to the server
            async submitEdit() {
                try {
                    await axios.put(`https://localhost:7018/api/Product/${this.UpdateProduct.productId}`, this.UpdateProduct);
                    const index = this.products.findIndex(p => p.productID === this.UpdateProduct.productId);
                    if (index !== -1) {
                        this.products.splice(index, 1, { ...this.UpdateProduct }); // Update the product in the list
                    }
                    this.editModalActive = false; // Hide the edit modal
                    toast.success("Product updated successfully", { autoClose: 500, position: 'top-right' });
                } catch (error) {
                    console.error('Error updating product:', error);
                    toast.error("Failed to update product", { autoClose:500, position: 'top-right' });
                }
            },

            // Add product to the cart (dummy function for demonstration)
            addToCart(productID) {
                console.log('Product added to cart:', productID);
            },

            // Show delete confirmation modal
            confirmDelete(productID) {
                this.confirmDeleteId = productID; // Store the product ID to be deleted
                this.deleteModalActive = true; // Show the delete confirmation modal
            },

            // Close delete confirmation modal
            closeDeleteModal() {
                this.deleteModalActive = false; // Hide the delete confirmation modal
            },

            // Delete a product
            async deleteProduct(productID) {
                try {
                    await axios.delete(`https://localhost:7018/api/Product/${productID}`);
                    this.products = this.products.filter(p => p.productID !== productID); // Remove the product from the list
                    this.closeDeleteModal(); // Hide the delete confirmation modal
                    toast.success("Product deleted successfully", { autoClose: 500, position: 'top-right' });
                } catch (error) {
                    console.error('Error deleting product:', error);
                    toast.error("Failed to delete product", { autoClose: 500, position: 'top-right' });
                }
            },

            // Show the image preview modal
            showImageModal(imageURL) {
                this.previewImageURL = imageURL;
                this.showModal = true; // Show the image preview modal
            },

            // Close the image preview modal
            closeImageModal() {
                this.showModal = false; // Hide the image preview modal
            },

            // Pagination: go to the next page
            nextPage() {
                if (this.currentPage < this.totalPages) {
                    this.currentPage++;
                }
            },

            // Pagination: go to the previous page
            prevPage() {
                if (this.currentPage > 1) {
                    this.currentPage--;
                }
            },

            // Toggle the liked status of a product
            toggleLike(product) {
                product.liked = !product.liked;
                if (product.liked) {
                    product.showFloatingHeart = true;
                    product.floatingMessage = "Added to Wishlist"; // Show floating heart and message
                    setTimeout(() => {
                        product.showFloatingHeart = false;
                    }, 1500);
                }
            }
        }
    }
</script>

<style scoped>
    /* Add necessary styles for the product list and modals */

    /* Floating heart animation */
    .floating-heart {
        position: absolute;
        top: 50%;
        left: 50%;
        transform: translate(-50%, -50%);
        z-index: 10;
        text-align: center;
        color: red;
        font-size: 1.5rem;
        display: flex;
        flex-direction: column;
        align-items: center;
    }

    .heart-animation {
        animation: floatUp 1.5s ease-out forwards;
    }

    @keyframes floatUp {
        0% {
            transform: translateY(0);
            opacity: 1;
        }

        100% {
            transform: translateY(-50px);
            opacity: 0;
        }
    }

    /* Modal styling */
    .modal.is-active .modal-content {
        display: flex;
        justify-content: center;
        align-items: center;
        background-color: white;
        padding: 0px;
        border-radius: 8px;
    }

    .modal-background {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background-color: rgba(0, 0, 0, 0.5);
    }

    .modal-content {
        margin-top:20px;
        z-index: 2;
        position: relative;
        width: 30%;
       
    }

    .modal-close {
        position: absolute;
        top: 10px;
        right: 10px;
        background: none;
        border: none;
        font-size: 1.5em;
        cursor: pointer;
        z-index: 3;
    }

    /* Image preview modal styling */
    .image-preview {
        width: 100%;
        height: auto;
    }

    .product-container .modal {
        display: flex;
        justify-content: center;
        align-items: center;
    }

    .modal-content {
        background: #fff;
        padding: 20px;
        border-radius: 8px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    }

    .button-container {
        display: flex;
        justify-content: flex-end;
        gap: 10px;
    }

    .like-icon {
        position: absolute;
        top: 10px;
        right: 10px;
        cursor: pointer;
    }

        .like-icon .bi-heart-fill {
            color: red;
        }

    /* Pagination controls */
    .pagination-controls {
        display: flex;
        justify-content: center;
        margin-bottom: 1rem;
    }

        .pagination-controls button {
            background: none;
            border: none;
            cursor: pointer;
            font-size: 1.2em;
        }

            .pagination-controls button[disabled] {
                opacity: 0.5;
                cursor: not-allowed;
            }

    /* Delete confirmation modal styles */
    .delete-modal {
        max-width: 500px;
        width: 100%;
        padding: 20px;
    }
</style>
