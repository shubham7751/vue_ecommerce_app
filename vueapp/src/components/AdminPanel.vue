<template>
    <div>
        <h1>Admin Panel</h1>
        <!-- Navigation links for managing products and categories -->
        <RouterLink to="/admin/products">Manage Products</RouterLink>
        <RouterLink to="/admin/categories">Manage Categories</RouterLink>
        <!-- Router view to render the child components -->
        <router-view></router-view>
    </div>
</template>
