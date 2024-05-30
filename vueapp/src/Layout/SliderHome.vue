<template>
    <div class="carousel-container" :class="{ 'full-page': isFullPage }">
        <div class="carousel">
            <div class="carousel-track" :style="trackStyle">
                <div class="carousel-slide" v-for="(image, index) in images" :key="index">
                    <img :src="image" :alt="'Slide ' + (index + 1)">
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                images: [
                    '/img/img1.jpg',
                    '/img/laptopbg.jpg',
                    '/img/bag.png',
                    '/img/iphone1.jpg',
                    //'/img/iphone14.jpg',
                    //'/img/iphone14_1.jpg',
                    //'/img/iphone2.jpg',
                ],
                currentIndex: 0,
                intervalId: null,
                isFullPage: false,
            };
        },
        computed: {
            trackStyle() {
                return {
                    transform: `translateX(-${this.currentIndex * 100}%)`,
                    transition: 'transform 0.5s ease-in-out',
                    width: `${100 / this.images.length}%`, // Set width of each slide dynamically
                };
            },
        },
        mounted() {
            this.startAutoSlide();
            window.addEventListener('keydown', this.handleKeyDown);
        },
        beforeUnmount() { // Use beforeUnmount for Vue 3
            this.stopAutoSlide();
            window.removeEventListener('keydown', this.handleKeyDown);
        },
        methods: {
            startAutoSlide() {
                this.intervalId = setInterval(this.nextSlide, 1000); // Change slide every 3 seconds
            },
            stopAutoSlide() {
                clearInterval(this.intervalId);
            },
            nextSlide() {
                this.currentIndex = (this.currentIndex + 1) % this.images.length;
            },
            handleKeyDown(event) {
                if (event.key === 'Enter') {
                    this.toggleFullPage();
                }
            },
            toggleFullPage() {
                this.isFullPage = !this.isFullPage;
            },
        },
    };
</script>
<style scoped>
    .carousel-container {
        overflow: hidden;
        width: 100%;
        height: 30%; /* Set height to 30% of the viewport height */
       
        position: relative; /* Ensure relative positioning for child elements */
    }

    .carousel {
        width: 100%;
        height: 30%; /* Fill the entire height of the carousel container */
        overflow: hidden;
    }

    .carousel-track {
        display: flex;
        transition: transform 0.20s ease-in-out;
    }

    .carousel-slide {
        min-width: 100%; /* Each slide takes full width */
        box-sizing: border-box;
        display: flex;
        justify-content: center;
        align-items: center;
    }

        .carousel-slide img {
            max-width: 100%; /* Ensures the image does not exceed the container width */
            max-height: 100%; /* Ensures the image does not exceed the container height */
            height: auto;
            object-fit: cover;
            border-radius: 10px;
            padding: 10px; /* Add padding to the image */
            margin: 0 auto; /* Center the image horizontally */
        }

    .full-page {
        position: fixed;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        z-index: 9999;
        background-color: rgba(0, 0, 0, 0.9); /* Adjust the background color and opacity */
    }

        .full-page .carousel {
            height: 100%;
        }
</style>

