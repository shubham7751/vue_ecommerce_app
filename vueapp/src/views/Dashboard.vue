<template>
    <div class="dashboard">
        <h2 class="dashboard-heading">Dashboard</h2>
        <div class="dashboard-content">
            <div class="analytics">
                <h3 class="section-title">Analytics</h3>
                <!-- Analytics content -->
                <p class="placeholder">Analytics data will be displayed here.</p>
            </div>
            <div class="sales-summary">
                <h3 class="section-title">Sales Summary</h3>
                <!-- Sales summary content -->
                <p class="placeholder">Sales summary data will be displayed here.</p>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  name: 'Dashboard'
}
</script>

<style scoped>
    /* Dashboard styles */
    .dashboard {
        padding: 20px;
    }

    .dashboard-heading {
        font-size: 24px;
        margin-bottom: 20px;
    }

    .dashboard-content {
        display: grid;
        grid-template-columns: repeat(auto-fit, minmax(300px, 1fr));
        gap: 20px;
    }

    .analytics,
    .sales-summary {
        background-color: #fff;
        border: 1px solid #ddd;
        border-radius: 5px;
        padding: 20px;
    }

    .section-title {
        margin-top: 0;
        margin-bottom: 10px;
        font-size: 18px;
    }

    .placeholder {
        color: #999;
        font-style: italic;
    }
</style>
