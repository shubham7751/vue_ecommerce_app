<!-- src/components/Footer.vue -->

<template>
    <footer>
        <div class="footer-content">
            <div class="footer-column">
                <h4>Company</h4>
                <ul>
                    <li> <router-link :to=" '/contactus' "><p>Contact Us</p></router-link></li>
                    <li>
                        <router-link :to=" '/about' "><p>About Us</p></router-link>
                    </li>
                    <li>Careers</li>
                </ul>
            </div>
            <div class="footer-column">
                <h4>Help</h4>
                <ul>
                    <li>Payments</li>
                    <li>Shipping</li>
                    <li>Returns</li>
                </ul>
            </div>
            <div class="footer-column">
                <h4>Policy</h4>
                <ul>
                    <li>Privacy Policy</li>
                    <li>Terms of Use</li>
                </ul>
            </div>
            <div class="footer-column">
    <h4>Follow Us</h4>
   <ul class="social-icons">
       <li>
           <a href="https://www.whatsapp.com" target="_blank"><i class="fab fa-whatsapp"  style="color: forestgreen;"></i></a>
       </li>
    <li><a href="https://www.facebook.com"><i class="fab fa-facebook-f" style="color: #1877f2;"></i></a></li> <!-- Facebook blue -->
    <li><a href="https://twitter.com"><i class="fab fa-twitter" style="color: #1da1f2;"></i></a></li> <!-- Twitter blue -->
    <li><a href="https://www.instagram.com"><i class="fab fa-instagram" style="color: #c13584;"></i></a></li> <!-- Instagram pink -->
    <li><a href="https://www.youtube.com"><i class="fab fa-youtube" style="color: #ff0000;"></i></a></li> <!-- YouTube red -->
</ul>

</div>

            <div class="footer-column">
                <h4>Location</h4>
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3780.0652680470854!2d73.9374741148931!3d18.546672987381676!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3bc2cb8d3b13b879%3A0x2f1a3192a21f14d8!2sWTC%20t1%20Kharadi%2C%20Pune%2C%20Maharashtra!5e0!3m2!1sen!2sin!4v1622039770358!5m2!1sen!2sin"
                        width="200" height="90" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0">
                </iframe>
            </div>

        </div>
    </footer>
</template>

<script>
export default {
  name: 'FooterPage'
}
</script>

<style scoped>
    /* Footer styles */
    footer {
        background-color: black ;
        color: white;
        padding: 50px;
        position: relative;
        width: 100%;
        bottom: 0;
    }

    .footer-content {
        display: flex;
        justify-content: space-between;
        max-width: 1200px;
        margin: 0 auto;

    }

    .footer-column {
        flex: 1;
        margin-right: 20px;
    }

        .footer-column h4 {
            font-size: 18px;
            margin-bottom: 10px;
        }

        .footer-column ul {
            list-style: none;
            padding: 0;
        }

            .footer-column ul li {
                margin-bottom: 5px;
            }

    .social-icons {
        list-style: none;
        padding: 0;
        display: flex;
    }

        .social-icons li {
            margin-right: 10px;
        }

        .social-icons a {
            color: #555;
            text-decoration: none;
            font-size: 20px;
        }

            .social-icons a:hover {
                color: #2874f0; /* Flipkart's blue color */
            }
</style>
