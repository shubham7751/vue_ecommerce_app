<template>
    <div class="carousel-container" style="margin-top:160px">
        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel" data-interval="2500">
            <div class="carousel-inner">
                <div class="carousel-item" :class="{ active: index === 0 }" v-for="(imagePair, index) in imagePairs" :key="index">
                    <div class="d-flex">
                        <img class="d-block w-50" :src="imagePair[0]" :alt="'Slide ' + (index + 1) + ' - Image 1'">
                        <img class="d-block w-50" :src="imagePair[1]" :alt="'Slide ' + (index + 1) + ' - Image 2'" v-if="imagePair[1]">
                    </div>
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
                    'https://img.freepik.com/premium-vector/online-shop-ads-banner-template_653829-11.jpg?size=626&ext=jpg&ga=ga1.1.1573671158.1712581185&semt=ais_user',
                    'https://img.freepik.com/free-psd/shopping-concept-banner-template_23-2148729463.jpg?size=626&ext=jpg&ga=GA1.1.1573671158.1712581185&semt=ais_user',
                    'https://img.freepik.com/premium-psd/special-offer-banner-with-3d-rendered-sale-concept_351527-1382.jpg?size=626&ext=jpg&ga=GA1.1.1573671158.1712581185&semt=ais_user',
                    'https://img.freepik.com/premium-vector/discount-social-media-banner-sale-with-discount-label_92715-314.jpg?size=626&ext=jpg&ga=GA1.1.1573671158.1712581185&semt=ais_user',

                ],
                currentIndex: 0,
            };
        },
        computed: {
            imagePairs() {
                let pairs = [];
                for (let i = 0; i < this.images.length; i += 2) {
                    pairs.push([this.images[i], this.images[i + 1] || null]);
                }
                return pairs;
            }
        },
        methods: {
            nextSlide() {
                if (this.currentIndex < this.imagePairs.length - 1) {
                    this.currentIndex++;
                } else {
                    this.currentIndex = 0;
                }
            },
            prevSlide() {
                if (this.currentIndex > 0) {
                    this.currentIndex--;
                } else {
                    this.currentIndex = this.imagePairs.length - 1;
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
        max-height: 300px; /* Adjust as needed */
        object-fit: cover;
    }
</style>
