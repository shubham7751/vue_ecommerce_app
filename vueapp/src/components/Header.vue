<template>
    <nav class="navbar navbar-expand-lg bg-dark navbar-dark fixed-top">
        <div class="container-fluid">
            <router-link to="/" class="navbar-brand">
                <img src="https://w7.pngwing.com/pngs/384/470/png-transparent-retail-computer-icons-e-commerce-sales-mega-offer-miscellaneous-service-logo.png" alt="E-CommerceWeb" width="100" height="50">
            </router-link>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                    <li class="nav-item">
                        <router-link :to="'/allProduct'" class="nav-link" aria-current="page">Product List</router-link>
                    </li>
                </ul>
                <form class="d-flex me-auto w-50" @submit.prevent="searchProducts">
                    <input class="form-control me-2" type="search" placeholder="Search" aria-label="Search" v-model="searchQuery">
                    <button class="btn btn-outline-success" type="submit">
                        <i class="bi bi-search"></i>
                    </button>
                </form>
                <ul class="navbar-nav ms-auto mb-2 mb-lg-0">
                    <li>
                        <router-link :to="'/likedproducts'" class="nav-link">
                            <i class="bi bi-heart h4"></i>
                        </router-link>
                    </li>
                    <li>
                        <router-link class="nav-link" :class="$route.name == 'Cart' ? 'active' : ''" aria-current="page" :to="{ name: 'Cart' }">
                            <i class="bi bi-cart3 h4"></i>
                            <span v-if="$store.state.cart.length > 0" class="pill-rounded justify-content-center align-items-center text-danger">
                                {{ $store.state.cart.length }}
                            </span>
                        </router-link>
                    </li>
                    <li>
                        <span v-if="loggedInUser" class="logged-in-user">{{ loggedInUser }}</span>
                        <button data-bs-toggle="offcanvas" data-bs-target="#userDrawer" aria-controls="userDrawer" class="logout-button">
                            <i class="bi bi-person h4" data-toggle="tooltip" data-placement="left" title="Login/Register"></i>
                        </button>
                    </li>
                </ul>
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
                loggedInUser: null, // Initially no user is logged in
                showSignupForm: false, // Control to show or hide the signup form
                searchQuery: '' // Model for the search query
            };
        },
        methods: {
            toggleForm() {
                this.showSignupForm = !this.showSignupForm;
            },
            logout() {
                // Perform logout actions here
                localStorage.removeItem('userEmail'); // Clear user email from local storage
                this.loggedInUser = null; // Reset loggedInUser
                this.$router.push({ path: '/login' }); // Redirect to login page
                this.toggleForm.hide();
            },
            searchProducts() {
                // Handle the search functionality here
                console.log('Search Query:', this.searchQuery);
                // You can use this.$router.push to navigate to a search results page
                this.$router.push({ path: '/search', query: { q: this.searchQuery } });
            }
        },
        created() {
            // Fetch the logged-in user's email from local storage or wherever it's stored
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
    .container-fluid {
        color: white;
        font-family: 'Times New Roman', Times, serif;
        font-size: 21px;
    }

    .logout-button {
        margin-left: 10px;
        border: none;
        font-weight: bold;
        padding: 10px;
    }

    .logged-in-user {
        margin-right: 10px; /* Adjust spacing between email and logout icon */
    }

    @keyframes zoomIn {
        from {
            transform: scale(0.9); /* Less pronounced zoom-in effect */
            opacity: 0;
        }

        to {
            transform: scale(1);
            opacity: 1;
        }
    }

    @keyframes zoomOut {
        from {
            transform: scale(1);
            opacity: 1;
        }

        to {
            transform: scale(0.9); /* Less pronounced zoom-out effect */
            opacity: 0;
        }
    }

    .custom-offcanvas {
        border-radius: 10px;
        margin-top: 20px;
        margin-right: 20px;
        height: auto;
        width: 270px; /* Adjust the width as needed */
        margin-bottom: 70px;
        animation-duration: 0.1s; /* Set the duration of the animation */
        animation-fill-mode: both;
    }

        .custom-offcanvas.show {
            opacity: 0;
            animation-name: zoomIn;
        }

    .offcanvas-backdrop.fade.show {
        opacity: 0; /* Adjust opacity as needed */
    }

    .custom-offcanvas:not(.show) {
        opacity: 0;
        animation-name: zoomOut;
    }

    .offcanvas-header {
        background-color: transparent;
        color: black;
        font-family: 'Times New Roman', Times, serif;
        font-size: 10px;
        display: flex;
        justify-content: flex-end;
    }

    .offcanvas-backdrop {
        /* Set a white background */
        opacity: 0;
        background-color: rgba(255, 255, 255, 1) !important;
        transition: none !important; /* Remove the fade transition */
    }

    .btn-close-red {
        background-color: red;
        border: none;
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
