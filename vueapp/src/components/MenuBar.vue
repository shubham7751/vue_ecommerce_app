<template>
    <nav class="navbar navbar-expand-lg navbar-light bg-light p-0 ">

        <div class="container-fluid">
            <router-link class="navbar-brand" to="/" style="font-size: 1.3rem;">
                Featured Products
            </router-link>
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
                <ul class="navbar-nav">
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
                            <li>
                                <router-link class="dropdown-item" to="/login">Sign In</router-link>
                            </li>
                            <li>
                                <router-link class="dropdown-item" to="/register">Sign Up</router-link>
                            </li>
                            <li>
                                <hr class="dropdown-divider" />
                            </li>
                            <li>
                                <router-link class="dropdown-item" to="/checkout">Checkout Page</router-link>
                            </li>
                            <li>
                                <router-link class="dropdown-item" to="/contact-us">Contact Us</router-link>
                            </li>
                            <li>
                                <router-link class="dropdown-item" to="/blog">Blog</router-link>
                            </li>
                            <li>
                                <router-link class="dropdown-item" to="/blog/detail">Blog Detail</router-link>
                            </li>
                            <li>
                                <hr class="dropdown-divider" />
                            </li>
                            <li>
                                <router-link class="dropdown-item" to="/fsafasf">404 Page Not Found</router-link>
                            </li>
                            <li>
                                <router-link class="dropdown-item" to="/500">500 Internal Server Error</router-link>
                            </li>
                        </ul>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Fashion |</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Supermarket |</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Electronics |</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Furniture |</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Garden & Outdoors |</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/category" style="font-size: 1.1rem;">Jewellery |</router-link>
                    </li>
                    <li class="nav-item">
                        <router-link class="nav-link" to="/documentation" style="font-size: 1.1rem;">Documentation |</router-link>
                    </li>
                    <!-- Language Button -->
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
                            <li>
                                <button class="dropdown-item" @click="changeLanguage('en')">English</button>
                            </li>
                            <li>
                                <button class="dropdown-item" @click="changeLanguage('mr')">Marathi</button>
                            </li>
                            <li>
                                <button class="dropdown-item" @click="changeLanguage('hi')">Hindi</button>
                            </li>
                        </ul>
                    </li>
                    <!-- End of Language Button -->
                </ul>
            </div>
        </div>
    </nav>
</template>

<script>
    export default {
        name: 'MenuBar',
        methods: {
            changeLanguage(lang) {
                // Add your language change logic here
                console.log(`Language changed to: ${lang}`);
            }
        }
    };
</script>

<style scoped>
    .navbar-nav .nav-link {
        font-size: 1.1rem;
    }
    .navbar {
        margin-top: 90px; /* Adjust the margin-top value as needed */
    }
</style>
