

<template>
    <div class="spinner-container">
        <div class="spinner"></div>
    </div>
</template>

<script>
    export default {
        props: {
            size: {
                type: String,
                default: '40px' // Default size of the spinner
            }
        }
    }

</script>
<style>
    .spinner-container {
        display: flex;
        justify-content: center;
        align-items: center;
        width: 100%;
        height: 100%;
       
    }

    .spinner {
        position: relative;
        width: 40px; /* Adjust size as needed */
        height: 40px; /* Adjust size as needed */
        border-radius: 50%;
        border: 6px dashed lightblue;
        animation: spin 1s linear infinite;
    }

        .spinner::before {
            content: '';
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            border: 6px dashed rgb(29, 199, 206, 0.10); /* Dashed border */
            border-radius: 50%;
        }

    @keyframes spin {
        0% {
            transform: rotate(0deg);
        }

        100% {
            transform: rotate(360deg);
        }
    }
</style>
