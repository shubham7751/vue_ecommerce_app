<template>
    
        <div class="product-container">
            <AddProductsModal></AddProductsModal>
            <div class="container min-h-content py-5 text-center" style="margin-bottom: 100px;">
                <!-- Pagination Controls -->
                <div class="pagination-controls" v-if="totalPages > 1">
                    <button @click="prevPage" :disabled="currentPage === 1">
                        <i class="cil-chevron-circle-left-alt"></i> <!-- Bootstrap Icons: Left Arrow -->
                    </button>
                    <button @click="nextPage" :disabled="currentPage === totalPages">
                        <i class="cil-chevron-circle-right-alt"></i>
                        <!-- Bootstrap Icons: Right Arrow -->
                    </button>
                </div>
                <div style="padding: 4px;" class="col-md-4" v-for="(product, index) in paginatedProducts" :key="index">
                    <div class="row py-lg-5">
                        <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
                            <div class="col" v-for="product in paginatedProducts" :key="product.id">
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
                                    <img class="bd-placeholder-img card-img-top" width="100%" :src="product.imageURL" alt="">
                                    <div class="card-body">
                                        <p class="card-text">{{ product.name }}</p>
                                        <div class="d-flex justify-content-between align-items-center">
                                            <div class="btn-group">
                                                <CartBTN :product="product" />
                                            </div>
                                            <small class="text-muted"><i class="bi bi-currency-dollar"></i>{{ product.price }}</small>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div style="display: flex; justify-content: center; align-items: flex-end; height: 100%;">
                <span>Page {{ currentPage }} of {{ totalPages }}</span>
            </div>
        
    </div>
    <!-- Edit Modal -->
    <div class="modal" :class="{ 'is-active': editModalActive }">
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
                    <label for="editDescription" class="form-label pink-bold">Description:</label>
                    <textarea id="editDescription" v-model="UpdateProduct.description" class="form-control" required></textarea>
                </div>
                <div class="mb-3">
                    <label for="editPrice" class="form-label">Price:</label>
                    <input type="number" id="editPrice" v-model="UpdateProduct.price" class="form-control" required>
                </div>
                <div class="mb-3">
                    <label for="editImage" class="form-label">Image:</label>
                    <textarea id="editImage" v-model="UpdateProduct.imageURL" class="form-control" required> </textarea>
                </div>
                <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                    <button type="submit" class="btn btn-primary me-md-2">Save</button>
                    <button type="button" @click="closeEditModal" class="btn btn-secondary">Cancel</button>
                </div>
            </form>
        </div>
    </div>
    <!-- Image Preview Modal -->
    <div class="modal" :class="{ 'is-active': showImageModal }">
        <div class="modal-content">
            <img :src="previewImageURL" alt="Preview Image" class="image-preview">
            <button class="modal-close is-small" aria-label="close" @click="closeImageModal">
                <i class="bi bi-x-lg"></i>
            </button>
        </div>
    </div>
</template>
<script>
    import axios from 'axios';
     import CartBTN from '../components/CartBTN.vue';
    import AddProductsModal from '@/components/AddProductsModal.vue';
    export default {

        data() {
            return {
                props: ['product'],

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
                productsPerPage: 3,
                showSuccessModal: false,
                showImageModal: false,
                previewImageURL: ''
            };
        },
        addToCart(id) {
            let data = {
                id: id,
                status: true
            }
            // Assuming you have access to the store via this.$store
            this.$store.commit('addToCart', id);
            this.$store.commit('setAddedBtn', data);
        },
        computed: {
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
        components: {
            CartBTN ,
            AddProductsModal
        },
        methods: {
                        toggleLike(product) {
                product.liked = !product.liked;
                const message = product.liked ? 'Liked' : 'Unliked';
                this.showFloatingHeartMessage(product, message);
                this.$store.commit('toggleLikeProduct', product);
            },
            showFloatingHeartMessage(product, message) {
                product.floatingMessage = message;
                product.showFloatingHeart = true;
                setTimeout(() => {
                    product.showFloatingHeart = false;
                }, 1000); // Show message for 1 second
            },
            async fetchProducts() {
                try {
                    const response = await axios.get('https://localhost:7018/api/Product');
                    this.products = response.data.reverse();
                } catch (error) {
                    console.error('Error fetching products:', error);
                }
            },
            async editProduct(product) {
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
                    this.showSuccessModal = true;
                } catch (error) {
                    console.error('Error updating product:', error);
                }
            },
            async deleteProduct(product) {
                const confirmed = window.confirm('Are you sure you want to delete this product?');
                if (confirmed) {
                    try {
                        await axios.delete(`https://localhost:7018/api/Product/${product.productID}`);
                        const index = this.products.findIndex(p => p.productID === product.productID);
                        if (index !== -1) {
                            this.products.splice(index, 1);
                        }
                    } catch (error) {
                        console.error('Error deleting product:', error);
                    }
                } else {
                    console.log('Deletion cancelled by user');
                }
            },

            nextPage() {
                if (this.currentPage < this.totalPages) {
                    this.currentPage++;
                }
            },
            prevPage() {
                if (this.currentPage > 1) {
                    this.currentPage--;
                }
            },
            openPreviewModal(imageURL) {
                this.previewImageURL = imageURL;
                this.showImageModal = true;
            },
            closeImageModal() {
                this.showImageModal = false;
                this.previewImageURL = '';
            }
        }
    };

</script>


<style>
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
