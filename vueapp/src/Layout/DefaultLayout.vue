<template>
    <div>
        <Header/>
        <MenuBar/>
         <router-view/>
        <Footer/>
    </div>
</template>
<script>
import Header from '@/views/Header.vue';
import Footer from '@/views/Footer.vue';
import MenuBar from '@/views/MenuBar.vue';
   
    export default {
        components: { Header, Footer, MenuBar }
}

</script>