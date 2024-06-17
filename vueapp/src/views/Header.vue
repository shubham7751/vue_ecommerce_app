<template>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark fixed-top">
        <div class="container-fluid">
            <router-link to="/" class="navbar-brand">
                <img src="../assets/Logo1.jpg.jpg" alt="E-CommerceWeb" width="120" height="60">
            </router-link>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent"
                    aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>

            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <router-link to="/allProduct" class="nav-link">All Products</router-link>
                    </li>
                </ul>
                <!-- Search Bar -->
                <form class="d-flex" @submit.prevent="searchProducts">
                    <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search" v-model="searchQuery">
                    <button class="btn btn-outline-success" type="submit"><i class="bi bi-search"></i></button>
                </form>
                <!-- End of Search Bar -->
                <!-- Right-Aligned Items -->
                <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <router-link to="/likedproducts" class="nav-link">
                            <i class="bi bi-heart h4"></i>
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <router-link :to="{ name: 'Cart' }" class="nav-link" :class="$route.name == 'Cart' ? 'active' : ''">
                            <i class="bi bi-cart3 h4"></i>
                            <span v-if="$store.state.cart.length > 0" class="pill-rounded justify-content-center align-items-center text-danger">
                                {{ $store.state.cart.length }}
                            </span>
                        </router-link>
                    </li>
                    <li class="nav-item">
                        <button class="btn logout-button" data-bs-toggle="offcanvas" data-bs-target="#userDrawer" aria-controls="userDrawer">
                            <i style="color:white"class="bi bi-person h4" data-toggle="tooltip" data-placement="left" title="Login/Register"></i>
                        </button>
                        <span v-if="loggedInUser" class="nav-link logged-in-user">{{ loggedInUser }}</span>
                    </li>
                </ul>
                <!-- End of Right-Aligned Items -->
            </div>
        </div>
    </nav>


    <!-- Drawer for Login and Sign Up -->
    <div class="offcanvas offcanvas-end custom-offcanvas" tabindex="-1" id="userDrawer" aria-labelledby="userDrawerLabel">
        <div class="offcanvas-header">
            <button type="button" class="btn-close" data-bs-dismiss="offcanvas" aria-label="Close"></button>
        </div>
        <div class="offcanvas-body">
            <Login v-if="!loggedInUser && !showSignupForm" @show-signup="toggleForm"></Login>
            <SignUp v-if="!loggedInUser && showSignupForm" @show-login="toggleForm"></SignUp>
            <button @click="logout" v-if="loggedInUser" class="btn btn-danger w-100">Logout</button>
        </div>
    </div>
</template>

<script>
    import SignUp from '@/views/SignUp.vue';
    import Login from '@/views/Login.vue';

    export default {
        name: 'HeaderPage',
        components: {
            Login,
            SignUp
        },
        data() {
            return {
                loggedInUser: null,
                showSignupForm: false,
                searchQuery: ''
            };
        },
        methods: {
            toggleForm() {
                this.showSignupForm = !this.showSignupForm;
            },
            logout() {
                localStorage.removeItem('userEmail');
                this.loggedInUser = null;
                this.$router.push({ path: '/login' });
                this.toggleForm.hide();
            },
            searchProducts() {
                console.log('Search Query:', this.searchQuery);
                this.$router.push({ path: '/search', query: { q: this.searchQuery } });
            },
            changeLanguage(lang) {
                console.log('Selected language:', lang);
                // Implement language change functionality here
            }
        },
        created() {
            const userEmail = localStorage.getItem('userEmail');
            if (userEmail) {
                this.loggedInUser = userEmail;
            }

            const backdrops = document.querySelectorAll('.offcanvas-backdrop');
            backdrops.forEach(backdrop => {
                backdrop.parentNode.removeChild(backdrop);
            });
        }
    }
</script>

<style scoped>
    /* Add your scoped styles here */
    .logout-button {
        margin-left: 10px;
        border: none;
        font-weight: bold;
        padding: 10px;
    }

    .logged-in-user {
        margin-right: 10px; /* Adjust spacing between email and logout icon */
    }

    .offcanvas-body {
        margin-top: 40px;
        padding-inline: 40px;
        padding: 20px;
    }

    button.btn-danger {
        margin-top: 20px;
    }
</style>
