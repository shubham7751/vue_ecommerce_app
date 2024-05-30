

<template>
    <SliderHome/>
    <div class="container min-h-content py-5 text-center" style="margin-bottom: 100px;">
        <!-- Pagination Controls -->
        <div class="pagination-controls" v-if="totalPages > 1">
            <button @click="prevPage" :disabled="currentPage === 1">
                <i class="cil-chevron-circle-left-alt"></i> <!-- Bootstrap Icons: Left Arrow -->
            </button>
            <button @click="nextPage" :disabled="currentPage === totalPages">
                <i class="cil-chevron-circle-right-alt"></i> <!-- Bootstrap Icons: Right Arrow -->
            </button>
        </div>

        <!-- Product Cards -->
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
                        <img class="bd-placeholder-img card-img-top" width="100%" :src="product.image" alt="">
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
</template>

<script>
    import CartBTN from '../components/CartBTN.vue';
     import SliderHome from '@/Layout/SliderHome.vue';
    export default {
        name: "HomeName",
        components: { CartBTN ,SliderHome
            },
        data() {
            return {
                products: [{ id: 1, name: 'iphone-13', image: '/img/iphone1.jpg', price: 60000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                { id: 2, name: 'iphone15', image: '/img/iphone14.jpg', price: 150000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                { id: 3, name: 'iphone14', image: '/img/iphone14_1.jpg', price: 50000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                { id: 4, name: 'iphone', image: '/img/iphone2.jpg', price: 40000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                { id: 5, name: 'iphone-13', image: '/img/iphone1.jpg', price: 60000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                { id: 7, name: 'iphone15', image: '/img/iphone14.jpg', price: 150000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                { id: 6, name: 'iphone14', image: '/img/iphone14_1.jpg', price: 50000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                { id: 8, name: 'iphone', image: '/img/iphone2.jpg', price: 40000, liked: false, showFloatingHeart: false, floatingMessage: '' },

                { id: 9, name: 'iphone-13', image: '/img/iphone1.jpg', price: 60000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                { id: 10, name: 'iphone15', image: '/img/iphone14.jpg', price: 150000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                { id: 11, name: 'iphone14', image: '/img/iphone14_1.jpg', price: 50000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                { id: 12, name: 'iphone', image: '/img/iphone2.jpg', price: 40000, liked: false, showFloatingHeart: false, floatingMessage: '' },
                ],

                currentPage: 1,
                itemsPerPage: 6 // Number of items per page
            };
        },
        computed: {
            paginatedProducts() {
                const startIndex = (this.currentPage - 1) * this.itemsPerPage;
                const endIndex = startIndex + this.itemsPerPage;
                return this.products.slice(startIndex, endIndex);
            },
            totalPages() {
                return Math.ceil(this.products.length / this.itemsPerPage);
            }
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
            setPage(pageNumber) {
                this.currentPage = pageNumber;
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