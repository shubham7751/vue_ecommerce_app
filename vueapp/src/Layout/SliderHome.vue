<template>
    <div class="carousel-container">
        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item" :class="{ active: index === 0 }" v-for="(image, index) in images" :key="index">
                    <img class="d-block w-100" :src="image" :alt="'Slide ' + (index + 1)">
                </div>
            </div>
            <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev" @click="prevSlide">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="sr-only">Previous</span>
            </a>
            <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next" @click="nextSlide">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="sr-only">Next</span>
            </a>
        </div>
    </div>
</template>

<script>
    export default {
        data() {
            return {
                images: [
                    'https://img.freepik.com/free-vector/flat-11-11-shopping-day-sale-banner-template_23-2149724057.jpg?size=626&ext=jpg&ga=GA1.1.1573671158.1712581185&semt=ais_user',
                    'https://img.freepik.com/free-vector/online-shopping-landing-page_23-2148787137.jpg?size=626&ext=jpg&ga=GA1.1.1573671158.1712581185&semt=ais_user',
                    'https://img.freepik.com/premium-vector/online-shop-ads-banner-template_653829-11.jpg?size=626&ext=jpg&ga=GA1.1.1573671158.1712581185&semt=ais_user',
                ],
                currentIndex: 0,
            };
        },
        methods: {
            nextSlide() {
                if (this.currentIndex < this.images.length - 1) {
                    this.currentIndex++;
                } else {
                    this.currentIndex = 0;
                }
            },
            prevSlide() {
                if (this.currentIndex > 0) {
                    this.currentIndex--;
                } else {
                    this.currentIndex = this.images.length - 1;
                }
            },
        },
    };
</script>

<style scoped>
    .carousel-container {
        margin-top: 30px; /* Adjust the margin-top to ensure it's below the header */
    }

    .carousel-item img {
        max-height: 500px; /* Adjust as needed */
        object-fit: cover;
    }
</style>
