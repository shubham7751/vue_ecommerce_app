<template>
    <div>
        <Header/>
        <MenuBar/>
         <router-view/>
        <Footer/>
    </div>
</template>
<script>
import Header from '@/components/Header.vue';
import Footer from '@/components/Footer.vue';
import MenuBar from '@/components/MenuBar.vue';
   
    export default {
        components: { Header, Footer, MenuBar }
}

</script>