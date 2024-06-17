<template>
    <section class="h-100 h-custom min-h-content" style="margin-top:120px">
        <div class="container py-5 h-100">
            <div class="row d-flex justify-content-center align-items-center h-50">
                <div class="col">
                    <div class="card border-0">
                        <div class="card-body p-4">

                            <div class="row">
                                <div class="col-lg-7">
                                    <h5 class="mb-3">
                                        <router-link :to="{ name: 'Home' }" class="text-body">
                                            <i class="fas fa-long-arrow-alt-left me-2"></i>Continue shopping
                                        </router-link>
                                    </h5>
                                    <hr>

                                    <div style="text-align:end;margin-left:500px">
                                        <div class="d-flex justify-content-end align-items-end mb-4">
                                            <p class="mb-0">You have {{ $store.state.cart.length }} items in your cart</p>
                                        </div>
                                    </div>
                                    <div class=" cart-items-list">
                                        <div v-for="item in $store.state.cart" class="card mb-3 shadow-sm border-0" :key="item.id">
                                            <div class="card-body">
                                                <div class="d-flex justify-content-between">
                                                    <div class="d-flex flex-row align-items-center">
                                                        <div>
                                                            <img :src="item.image || item.imageURL" class="img-fluid rounded-3" alt="Shopping item" style="width: 65px;">
                                                        </div>
                                                        <div class="ms-3" style="width: 200px; height: auto;">
                                                            <p>{{ item.name }}</p>
                                                        </div>
                                                    </div>
                                                    <div class="d-flex flex-row align-items-center">
                                                        <div>
                                                            <CartAddRemove :product="item" />
                                                        </div>
                                                    </div>
                                                    <div class="d-flex flex-row align-items-center">
                                                        <div>
                                                            <h5 class="mb-0">₹{{ item.price * item.qty }}</h5>
                                                            <small v-if="item.hasDiscount" class="text-muted text-decoration-line-through">₹{{ item.price }}</small>
                                                        </div>
                                                        <a role="button" @click="removeItem(item)" class="ms-4" style="color: #cecece;"><i class="bi bi-trash3 h4"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-5">

                                    <div class="card outline-secondary text-black rounded-0 border-0">
                                        <div class="card-body">
                                            <div class="d-flex justify-content-between align-items-center mb-4">
                                                <h5 class="mb-0">Cart details</h5>
                                                <i class="bi bi-cart3 h1"></i>
                                            </div>
                                            <hr class="my-4">
                                            <div class="d-flex justify-content-between">
                                                <p class="mb-2">Subtotal</p>
                                                <p class="mb-2">₹{{ $store.state.cartTotal }}</p>
                                            </div>
                                            <div class="d-flex justify-content-between mb-4">
                                                <p class="mb-2">Total</p>
                                                <p class="mb-2">₹{{ $store.state.cartTotal }}</p>
                                            </div>

                                            <!-- Checkout Button with Router Link -->
                                            <router-link to="/CheckOut" class="btn btn-info btn-block btn-lg">
                                                Checkout
                                            </router-link>

                                        </div>
                                    </div>

                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>

<script>
    import CartAddRemove from '../components/CartAddRemove.vue';
    export default {
        name: "CartName",
        components: { CartAddRemove },
        methods: {
            removeItem(item) {
                this.$store.commit('addRemoveCart', { product: item, toAdd: false })
            },
        },
        mounted() { }
    }
</script>

<style scoped>
    /* Modal styles */
    .modal {
        display: flex;
        justify-content: center;
        align-items: center;
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background: rgba(0, 0, 0, 0.5);
        z-index: 1000;
    }

    .modal-background {
        position: absolute;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        background: rgba(0, 0, 0, 0.5);
    }

    .modal-content {
        position: relative;
        background: white;
        padding: 20px;
        border-radius: 8px;
        z-index: 1001;
    }

    .delete-modal {
        max-width: 500px;
        width: 100%;
        padding: 20px;
        text-align: center; /* Center align text inside the modal */
    }
    .cart-items-list {
        /* Ensure it doesn't exceed certain height and scrolls if necessary */
        max-height: 400px; /* Adjust as per your design */
        overflow-y: auto; /* Enable vertical scrolling */
    }
        .delete-modal h2 {
            margin-bottom: 20px;
        }

        .delete-modal .d-grid {
            gap: 10px;
        }
</style>
