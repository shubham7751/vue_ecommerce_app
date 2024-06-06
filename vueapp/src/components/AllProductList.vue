<template>
    <div class="product-container">
        <br />
        <AddProductsModal @productAdded="fetchProducts"></AddProductsModal>
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
            <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
                <div class="col" v-for="(product, index) in paginatedProducts" :key="index">
                    <div class="card shadow-sm">
                        <!-- Like icon -->
                        <div class="like-icon">
                            <i class="bi bi-heart bi-heart-empty Likebtnicon"
                               @click="toggleLike(product)"
                               :class="{ 'bi-heart-fill': product.liked }"></i>
                        </div>
                        <!-- Floating heart animation container for each product -->
                        <div v-if="product.showFloatingHeart" class="floating-heart">
                            <i class="bi bi-heart-fill heart-animation"></i>
                            <p>{{ product.floatingMessage }}</p>
                        </div>
                        <div class="product-image">
                            <img @click="showImageModal(product.imageURL)" :src="product.imageURL" :width="imgWidth" :height="imgHeight" alt="Image not available here">
                        </div>
                        <div class="card-body">
                            <p class="card-text">{{ product.name }}</p><br />
                            <div class="d-flex justify-content-between align-items-center">
                                <div class="btn-group">
                                    <CartBTN :product="product" @addToCart="addToCart(product.productID)" />
                                </div>
                                <small class="text-muted"><i class="bi bi-currency-dollar"></i>{{ product.price }}</small>
                            </div><br />
                            <div class="button-container">
                                <button @click="editProduct(product)" class="btn btn-sm btn-outline-secondary me-2">
                                    <i class="bi bi-pencil"></i>
                                </button>
                                <button @click="deleteProduct(product.productID)" class="btn btn-sm btn-outline-danger">
                                    <i class="bi bi-trash"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div style="display: flex; justify-content: center; align-items: flex-end; height: 100%;">
            <span>Page {{ currentPage }} of {{ totalPages }}</span>
        </div>
        <!-- Edit Modal -->
        <div v-if="editModalActive" class="modal is-active">
            <div class="modal-background" @click="closeEditModal"></div>
            <div class="modal-content">
                <form @submit.prevent="submitEdit" class="p-3">
                    <h2 class="mb-4">Edit Product</h2>
                    <button class="modal-close is-small" aria-label="close" @click="closeEditModal">
                        <i class="bi bi-x-lg"></i>
                    </button>
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
                        <label for="editImage" class="form-label">Image:</label>
                        <textarea id="editImage" v-model="UpdateProduct.imageURL" class="form-control" required></textarea>
                    </div>
                    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                        <button type="submit" class="btn btn-primary me-md-2">Save</button>
                        <button type="button" @click="closeEditModal" class="btn btn-secondary">Cancel</button>
                    </div>
                </form>
            </div>
        </div>
        <!-- Image Preview Modal -->
        <div class="modal" v-if="showModal">
            <div class="modal-content">
                <img :src="previewImageURL" alt="Preview Image" class="image-preview">
                <button class="modal-close is-small" aria-label="close" @click="closeImageModal">
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
    import AddProductsModal from '@/components/AddProductsModal.vue';

    export default {
        name: 'ProductList',
        components: {
            CartBTN,
            AddProductsModal
        },
        data() {
            return {
                imgWidth: 220,
                products: [],
                editModalActive: false,
                UpdateProduct: {
                    productId: null,
                    name: '',
                    brand: '',
                    description: '',
                    price: 0,
                    imageURL: ''
                },
                currentPage: 1,
                productsPerPage: 6,
                showSuccessModal: false,
                previewImageURL: '', // Initialize previewImageURL as an empty string
                showModal: false, 
            };
        },
        computed: {
            imgHeight() {
                return Math.round(this.imgWidth * 1);
            },
            totalPages() {
                return Math.ceil(this.products.length / this.productsPerPage);
            },
            paginatedProducts() {
                const start = (this.currentPage - 1) * this.productsPerPage;
                const end = start + this.productsPerPage;
                return this.products.slice(start, end);
            }
        },
        created() {
            this.fetchProducts();
        },
        methods: {
            ...mapActions(['addProduct', 'updateProduct', 'deleteProduct']),

            async fetchProducts() {
                try {
                    const response = await axios.get('https://localhost:7018/api/Product');
                    this.products = response.data.reverse();
                } catch (error) {
                    console.error('Error fetching products:', error);
                }
            },

            editProduct(product) {
                this.UpdateProduct = { ...product };
                this.UpdateProduct.productId = product.productID;
                this.editModalActive = true;
            },

            closeEditModal() {
                this.editModalActive = false;
            },

            async submitEdit() {
                try {
                    const id = this.UpdateProduct.productId;
                    const response = await axios.put(`https://localhost:7018/api/Product/${id}`, this.UpdateProduct);
                    console.log('Product updated:', response.data);

                    const index = this.products.findIndex(p => p.productID === id);
                    if (index !== -1) {
                        this.products.splice(index, 1, this.UpdateProduct);
                    }

                    this.editModalActive = false;
                    toast.success("Product updated successfully", { autoClose: 3000, position: 'top-right' });
                } catch (error) {
                    console.error('Error updating product:', error);
                    toast.error("Error updating product", { autoClose: 3000, position: 'top-right' });
                }
            },

            async deleteProduct(ProductID) {
                const confirmed = window.confirm('Are you sure you want to delete this product?');
                if (confirmed) {
                    try {
                        await axios.delete(`https://localhost:7018/api/Product/${ProductID}`);
                        const index = this.products.findIndex(p => p.ProductID === ProductID);
                        if (index !== -1) {
                            this.products.splice(index, 1);
                        }
                        toast.success("Product deleted successfully", { autoClose: 3000, position: 'top-right' });
                    } catch (error) {
                        console.error('Error deleting product:', error);
                        toast.error("Error deleting product", { autoClose: 3000, position: 'top-right' });
                    }
                } else {
                    console.log('Deletion cancelled by user');
                }
            },

            toggleLike(product) {
                product.liked = !product.liked;
                const message = product.liked ? 'Added to Wishlist' : 'Removed from Wishlist';
                product.floatingMessage = message;

                product.showFloatingHeart = true;
                setTimeout(() => {
                    product.showFloatingHeart = false;
                }, 2000);

                const toastType = product.liked ? toast.success : toast.error;
                toastType(message, { autoClose: 3000, position: 'top-right' });
            },

            addToCart(productId) {
                console.log('Add to cart:', productId);
                // Add to cart functionality
            },

            prevPage() {
                if (this.currentPage > 1) {
                    this.currentPage--;
                }
            },

            nextPage() {
                if (this.currentPage < this.totalPages) {
                    this.currentPage++;
                }
            },

            showImageModal(imageURL) {
                console.log('Image URL:', imageURL); // Log the imageURL being passed to the method
                this.previewImageURL = imageURL;
                this.showModal = true; // Set showModal to true to display the modal
            },

            // Method to close the image preview modal
            closeImageModal() {
                this.showModal = false; // Set showModal to false to hide the modal
            }
        }
    };
</script>



<style>
    /* CSS for image preview modal */
    .modal {
        display: none; /* Hide modal by default */
        position: fixed;
        z-index: 9999; /* Ensure modal appears on top of other content */
        left: 0;
        top: 0;
        width: 100%;
        height: 100%;
        overflow: auto;
        background-color: rgba(0, 0, 0, 0.7); /* Semi-transparent black background */
    }

    .modal-content {
        position: relative;
        margin: auto;
        width: 80%; /* Adjust modal width as needed */
        max-width: 700px; /* Set maximum width for modal content */
        background-color: red; /* White background */
        border-radius: 8px; /* Add border radius for rounded corners */
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); /* Add box shadow for depth */
    }

    .image-preview {
        display: block;
        margin: auto;
        max-width: 100%; /* Ensure image fits within modal content */
        max-height: 80vh; /* Limit maximum height of image to 80% of viewport height */
        border-radius: 8px 8px 0 0; /* Rounded corners only on top */
    }

    .modal-close {
        position: absolute;
        top: 10px;
        right: 10px;
        background: none;
        border: none;
        cursor: pointer;
        font-size: 20px;
        color: #333; /* Dark color for close icon */
    }

    .button-container {
        display: flex;
        justify-content: flex-end;
    }
    .product-image {
        display: flex;
        align-items: center;
        justify-content: center;
    }
    .like-icon {
        position: absolute;
        top: 10px;
        right: 10px;
        z-index: 1;
    }

    .Likebtnicon {
        color: black; /* Empty heart color */
        cursor: pointer;
    }

    .bi-heart-empty {
        color: black; /* Empty heart color */
    }

    .bi-heart-fill {
        color: red; /* Filled heart color */
    }

    /* Change heart color to red on hover for heart icon with class "Likebtnicon" */
    .Likebtnicon:hover {
        color: red;
    }

    /* Floating heart animation styles */
    .floating-heart {
        position: absolute;
        top: 0;
        left: 50%;
        transform: translateX(-50%);
        z-index: 1000;
        display: flex;
        flex-direction: column;
        align-items: center;
        animation: fadeOut 1s forwards;
    }

    .pagination-container {
        background-color: transparent;
        position: relative; /* Set the position to absolute */
        bottom: 20px; /* Adjust the distance from the bottom */
        transform: translateX(-50%); /* Adjust to center horizontally */
        display: flex;
        align-items: center;
        justify-content: space-between;
        width: 100%; /* Ensure the pagination controls span the entire width */
        max-width: 900px; /* Adjust the maximum width as needed */
    }

    .pagination-controls {
        background-color: transparent;
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        margin-top: 520px;
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 10px;
    }

        .pagination-controls button {
            background-color: transparent;
            border: none;
            cursor: pointer;
            font-size: 24px;
            color: #007bff; /* Bootstrap primary color */
        }

            .pagination-controls button:disabled {
                color: #6c757d; /* Bootstrap secondary color */
                cursor: not-allowed;
            }

    .heart-animation {
        color: red;
        font-size: 2rem;
        animation: floatUp 1s;
    }

    @keyframes floatUp {
        0% {
            transform: translateY(0);
        }

        100% {
            transform: translateY(-20px);
        }
    }

    @keyframes fadeOut {
        0% {
            opacity: 1;
        }

        100% {
            opacity: 0;
        }
    }
</style>
