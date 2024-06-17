<template>
    <div>
        <!-- Explore Fashion Collection Section -->
        <div class="bg-info bg-gradient p-3 text-center mb-3">
            <h4 class="m-0">Explore Fashion Collection</h4>
        </div>
        <div class="container">
            <div class="row text-center">
                <!-- Add your fashion categories here -->
                <div class="col-md-2" v-for="category in categories" :key="category.name">
                    <a :href="category.link" class="text-decoration-none">
                        <img :src="category.img"
                             class="img-fluid rounded-circle rounded-icon fashion-category-img"
                             :alt="category.name" />
                        <div class="text-center h6">{{ category.name }}</div>
                    </a>
                </div>
            </div>
        </div>
    </div>


</template>

<script>
    export default {
        name: 'ExploreFashion',
        data() {
            return {
                categories: [
                    {
                        name: 'Head Phones',
                        img: 'https://cdn-icons-png.freepik.com/512/223/223118.png',
                        link: '/'
                    },
                    {
                        name: 'T-Shirts',
                        img: 'https://cdn-icons-png.freepik.com/512/340/340395.png',
                        link: '/'
                    },
                    {
                        name: 'Watches',
                        img: 'https://c0.klipartz.com/pngpicture/266/241/gratis-png-todo-el-arte-del-reloj-analogico-redondo-blanco-y-rojo-controlador-de-la-ciudad-de-los-angeles-informe-financiero-anual-completo-auditoria-estado-financiero-reloj-guardar-icono-de-thumbnail.png',
                        link: '/'
                    },
                    {
                        name: 'Footwear',
                        img: 'https://cdn-icons-png.freepik.com/512/5487/5487101.png',
                        link: '/'
                    },
                    {
                        name: 'Mobiles',
                        img: 'https://cdn-icons-png.flaticon.com/512/3616/3616049.png',
                        link: '/'
                    },
                    {
                        name: 'Laptops',
                        img: 'https://cdn-icons-png.flaticon.com/512/432/432787.png',
                        link: '/'
                    }
                ]
            };
        }
    };
</script>

<style scoped>
    .bg-info {
        background-color: #17a2b8 !important;
    }

    .bg-gradient {
        background: linear-gradient(180deg, rgba(23, 162, 184, 1) 0%, rgba(133, 193, 233, 1) 100%);
    }

    .fashion-category-img {
        max-width: 100px;
        height: auto;
    }

    .text-center {
        text-align: center;
    }
</style>
