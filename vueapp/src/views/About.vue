<template>
    <div class="about-us">
        <section class="hero">
            <h1>About Us</h1>
            <p>Discover our story, mission, and the people behind our brand.</p>
        </section>

        <section class="story">
            <h2>Our Story</h2>
            <p>Founded in 2020, we have grown from a small startup to a leading e-commerce platform...</p>
        </section>

        <section class="vision">
            <h2>Our Vision</h2>
            <p>To be the most customer-centric e-commerce platform where people can find and discover anything they want to buy online.</p>
        </section>
        
        <section class="values">
            <h2>Our Values</h2>
            <ul>
                <li>Customer Commitment: We develop relationships that make a positive difference in our customers' lives.</li>
                <li>Quality: We provide outstanding products and unsurpassed service that, together, deliver premium value to our customers.</li>
                <li>Integrity: We uphold the highest standards of integrity in all of our actions.</li>
                <li>Teamwork: We work together, across boundaries, to meet the needs of our customers and to help our company win.</li>
            </ul>
        </section>

        <section class="history">
            <h2>Our History</h2>
            <div class="timeline">
                <div class="timeline-item">
                    <h3>2020</h3>
                    <p>Company founded and launched first product line.</p>
                </div>
                <div class="timeline-item">
                    <h3>2021</h3>
                    <p>Expanded product range and reached 100,000 customers.</p>
                </div>
                <div class="timeline-item">
                    <h3>2022</h3>
                    <p>Opened our first international office.</p>
                </div>
                <!-- Add more timeline items as needed -->
            </div>
        </section>

        <section class="testimonials">
            <h2>Customer Testimonials</h2>
            <div class="testimonial">
                <p>"Fantastic service and great products! Highly recommend." - Jane Doe</p>
            </div>
            <div class="testimonial">
                <p>"I've been a loyal customer for years. They never disappoint." - John Smith</p>
            </div>
            <!-- Add more testimonials as needed -->
        </section>

        <section class="team">
            <h2>Meet the Team</h2>
            <div class="team-members">
                <div class="team-member">
                    <img src="https://t4.ftcdn.net/jpg/03/83/25/83/360_F_383258331_D8imaEMl8Q3lf7EKU2Pi78Cn0R7KkW9o.jpg" alt="Team Member 1">
                    <h3>Nita Mishtra</h3>
                    <p>CEO & Founder</p>
                </div>
                <div class="team-member">
                    <img src="https://t3.ftcdn.net/jpg/02/43/12/34/360_F_243123463_zTooub557xEWABDLk0jJklDyLSGl2jrr.jpg" alt="Team Member 2">
                    <h3>Kunal Shaha</h3>
                    <p>Chief Operating Officer</p>
                </div>
                <!-- Add more team members as needed -->
            </div>
        </section>

        <section class="contact">
            <h2>Contact Us</h2>
            <p>
                If you have any questions, feel free to 
                                                        <router-link :to=" '/contactus' " >contact us</router-link>.
            </p>
        </section>
    </div>
</template>

<script>
export default {
  name: 'AboutUs'
}
</script>

<style scoped>
    .about-us {
        padding: 20px;
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

    p {
        font-size: 1em;
        color: #333;
        line-height: 1.6;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

        ul li {
            background: #f0f0f0;
            margin: 10px 0;
            padding: 10px;
            border-radius: 5px;
        }

    .timeline {
        display: flex;
        flex-direction: column;
    }

    .timeline-item {
        padding: 10px;
        margin: 10px 0;
        border-left: 3px solid #007bff;
        padding-left: 10px;
    }

    .testimonial {
        background: #f0f0f0;
        padding: 15px;
        border-radius: 5px;
        margin: 10px 0;
    }

    .team-members {
        display: flex;
        flex-wrap: wrap;
    }

    .team-member {
        flex: 1 1 200px;
        text-align: center;
        margin: 10px;
    }

        .team-member img {
            width: 150px;
            height: 150px;
            border-radius: 50%;
            object-fit: cover;
            margin-bottom: 10px;
        }

        .team-member h3 {
            font-size: 1.2em;
            margin-bottom: 5px;
        }

        .team-member p {
            font-size: 1em;
            color: #777;
        }

    .contact a {
        color: #007bff;
        text-decoration: none;
    }

        .contact a:hover {
            text-decoration: underline;
        }
</style>
