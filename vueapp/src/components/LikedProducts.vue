<template>
    <div class="container min-h-content py-5 text-center" style="display: flex; flex-direction: column;">
        <h5 class="mb-3">
            <router-link :to="{name:'Home'}" class="text-body"><i class="bi bi-shop"></i> &nbsp; Continue shopping</router-link>
        </h5>
        <hr>
        <div v-if="likedProducts.length" class="row py-lg-5">
            <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
                <div class="col" v-for="product in likedProducts" :key="product.id">
                    <div class="card shadow-sm">
                        <!-- Like icon -->
                        <div class="like-icon">
                            <i class="bi bi-heart bi-heart-empty Likebtnicon"
                               @click="toggleLike(product)"
                               :class="{ 'bi-heart-fill': isProductLiked(product) }"></i>
                        </div>
                        <!-- Floating heart animation container for each product -->
                        <div v-if="product.showFloatingHeart" class="floating-heart">
                            <div class="heart-background">
                                <i class="bi bi-heart-fill heart-animation"></i>
                            </div>
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
        <div v-else>
            <p>No liked products</p>
        </div>
    </div>
</template>

<script>
    import CartBTN from './CartBTN.vue';

    export default {
        components: { CartBTN },
        computed: {
            likedProducts() {
                return this.$store.getters.likedProducts;
            }
        },
        methods: {
            toggleLike(product) {
                this.$store.commit('toggleLikeProduct', product);
                this.showFloatingHeart(product);
            },
            isProductLiked(product) {
                return this.$store.getters.isProductLiked(product);
            },
            showFloatingHeart(product) {
                product.showFloatingHeart = true;
                product.floatingMessage = this.isProductLiked(product) ? 'Liked!' : 'Unliked!';
                setTimeout(() => {
                    product.showFloatingHeart = false;
                }, 1000);
            }
        }
    };
</script>

<style scoped>
    .like-icon {
        position: absolute;
        top: 10px;
        right: 10px;
        z-index: 1;
    }

    .bd-placeholder-img {
        object-fit: cover;
    }

    .bi-heart {
        color: black; /* Empty heart color */
        cursor: pointer;
    }

    .bi-heart-fill {
        color: red; /* Filled heart color */
    }

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

    .heart-background {
        background-color: pink;
        border-radius: 50%;
        padding: 10px;
        display: flex;
        align-items: center;
        justify-content: center;
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
