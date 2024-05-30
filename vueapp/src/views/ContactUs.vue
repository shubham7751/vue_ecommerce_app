<template>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    
        <VaSkeletonGroup>
            <VaCard>
                <VaSkeleton variant="squared" height="120px" />
                <VaCardContent class="flex items-center">
                    <VaSkeleton variant="circle" width="1rem" height="48px" />
                    <VaSkeleton variant="text" class="ml-2" :lines="2" />
                </VaCardContent>
                <VaCardContent>
                    <VaSkeleton variant="text" :lines="4" text-width="50%" />
                </VaCardContent>
                <VaCardActions class="flex justify-end">
                    <VaSkeleton class="mr-2"
                                variant="rounded"
                                inline
                                width="64px"
                                height="32px" />
                    <VaSkeleton variant="rounded" inline width="64px" height="32px" />
                </VaCardActions>
            </VaCard>
        </VaSkeletonGroup>

    <div class="contact-us">
        <section class="hero" style="background-image: url('../assets/bg-images/img1.jpg'); ">

            <h1>Contact Us</h1>
            <p>We're here to help. Get in touch with us!</p>
        </section>

        <section class="contact-form" style="background-image: url('~@/assets/bg-images/contact-form-bg.jpg');">
            <h2>Send Us a Message</h2>
            <form @submit.prevent="submitForm">
                <div class="form-group">
                    <label for="name">Name</label>
                    <input type="text" id="name" v-model="form.name" required>
                </div>
                <div class="form-group">
                    <label for="email">Email</label>
                    <input type="email" id="email" v-model="form.email" required>
                </div>
                <div class="form-group">
                    <label for="message">Message</label>
                    <textarea id="message" v-model="form.message" required></textarea>
                </div>
                <button type="submit">Submit</button>
            </form>
        </section>

        <section class="company-info" style="background-image: url('~@/assets/bg-images/company-info-bg.jpg');">
            <h2>Our Information</h2>
            <p><strong>Address:</strong> 123 E-commerce St, Suite 100, Online City, EC 12345</p>
            <p><strong>Email:</strong> <a href="mailto:support@ecommerce.com">support@ecommerce.com</a></p>
            <p><strong>Phone:</strong> <a href="tel:+1234567890">+1 234 567 890</a></p>
        </section>

        <section class="map" style="background-image: url('~@/assets/bg-images/map-bg.jpg');">
            <h2>Our Location</h2>
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3780.0652680470854!2d73.9374741148931!3d18.546672987381676!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bc2cb8d3b13b879%3A0x2f1a3192a21f14d8!2sWTC%20t1%20Kharadi%2C%20Pune%2C%20Maharashtra!5e0!3m2!1sen!2sin!4v1622039770358!5m2!1sen!2sin"
                    width="200" height="90" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0">
            </iframe>
        </section>

        <section class="social-media" style="background-image: url('~@/assets/bg-images/social-media-bg.jpg');">
            <h2>Connect with Us</h2>
            <a href="https://www.facebook.com" target="_blank"><i class="fab fa-facebook"></i></a>
            <a href="https://www.twitter.com" target="_blank"><i class="fab fa-twitter"></i></a>
            <a href="https://www.instagram.com" target="_blank"><i class="fab fa-instagram"></i></a>
            <a href="https://www.linkedin.com" target="_blank"><i class="fab fa-linkedin"></i></a>
            <a href="https://www.whatsapp.com" target="_blank"><i class="fab fa-whatsapp"></i></a>


        </section>
    </div>
</template>

<script>
    export default {
        name: 'ContactUs',
        data() {
            return {
                form: {
                    name: '',
                    email: '',
                    message: ''
                }
            }
        },
        methods: {
            submitForm() {
                // Handle form submission logic here
                console.log('Form submitted:', this.form)
                alert('Thank you for your message!')
                this.form.name = ''
                this.form.email = ''
                this.form.message = ''
            }
        }
    }
</script>

<style scoped>
    .contact-us {
        font-family: Arial, sans-serif;
    }

    .hero {
        text-align: center;
        margin-bottom: 40px;
        background: #f8f8f8;
        padding: 20px;
        border-radius: 10px;
    }

        .hero h1 {
            font-size: 2.5em;
            margin-bottom: 10px;
        }

        .hero p {
            font-size: 1.2em;
            color: #555;
        }

    section {
        margin-bottom: 40px;
    }

    h2 {
        font-size: 2em;
        margin-bottom: 10px;
        border-bottom: 2px solid #ddd;
        padding-bottom: 5px;
    }

    .contact-form {
        padding:50px;
        background: #f8f8f8;
        justify-content: center; /* Horizontally center the form */
        align-items: center; /* Vertically center the form */
        height: 100vh; /* Adjust as needed */
    }

    .form-group {
        margin-bottom: 15px;
    }

        .form-group label {
            display: block;
            margin-bottom: 5px;
        }

        .form-group input,
        .form-group textarea {
            width: 100%;
            padding: 10px;
            border: 1px solid #ddd;
            border-radius: 5px;
        }

    button {
        padding: 10px 20px;
        background: #007bff;
        color: white;
        border: none;
        border-radius: 5px;
        cursor: pointer;
    }

        button:hover {
            background: #0056b3;
        }

    .company-info {
        background: #f8f8f8;
        padding: 20px;
        border-radius: 10px;
    }

        .company-info p {
            font-size: 1em;
            color: #333;
        }

        .company-info a {
            color: #007bff;
            text-decoration: none;
        }

            .company-info a:hover {
                text-decoration: underline;
            }

    .map iframe {
        width: 50%;
        height: 300px;
        border: none;
        border-radius: 10px;
    }

    .social-media {
        text-align: center;
    }

        .social-media a {
            margin: 0 10px;
            color: #007bff;
            text-decoration: none;
            font-size: 1.2em;
        }

            .social-media a:hover {
                text-decoration: underline;
            }
</style>
