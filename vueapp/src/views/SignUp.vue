<template>
    <div>
        <!-- Sign-up form -->
        <div class="signup-form-container">
            <div class="signup-form">
                <h2 class="text-center mb-4">Sign Up</h2>
                <form @submit.prevent="submitForm" class="formcss">
                    <div class="form-group">
                        <label for="username">Username</label>
                        <input type="text" id="username" v-model="formData.username" class="form-control" required>
                        <span v-if="errors.username" class="error">{{ errors.username }}</span>
                    </div>
                    <div class="form-group">
                        <label for="name">Name</label>
                        <input type="text" id="name" v-model="formData.name" class="form-control" required>
                        <span v-if="errors.name" class="error">{{ errors.name }}</span>
                    </div>
                    <div class="form-group">
                        <label for="email">Email</label>
                        <input type="email" id="email" v-model="formData.email" class="form-control" required>
                        <span v-if="errors.email" class="error">{{ errors.email }}</span>
                    </div>
                    <div class="form-group">
                        <label for="password">Password</label>
                        <input type="password" id="password" v-model="formData.password" class="form-control" required>
                        <span v-if="errors.password" class="error">{{ errors.password }}</span>
                    </div><br />
                    <button type="submit" class="btn btn-primary btn-block">Sign Up</button>
                    <p>Already have an account? <a href="#" class="signup-link" @click.prevent="$emit('show-login')"> Login here</a> </p>

                </form>
            </div>
        </div>
    </div>
</template>

<script>
    import axios from 'axios';
    import 'bootstrap-icons/font/bootstrap-icons.css';

    export default {
        name: 'SignUp',
        data() {
            return {
                formData: {
                    username: '',
                    name: '',
                    email: '',
                    password: ''
                },
                errors: {}
            };
        },
        methods: {
            submitForm() {
                this.validateForm();
                if (Object.keys(this.errors).length === 0) {
                    axios.post('https://localhost:7018/api/Authentication/registration', this.formData)
                        .then(response => {
                            if (response && response.data) {
                                // Handle success response here
                                console.log('User registered successfully:', response.data);
                            } else {
                                console.error('Empty response received from server');
                            }
                        })
                        .catch(error => {
                            if (error.response && error.response.data) {
                                // Handle error response here
                                console.error('Error registering user:', error.response.data);
                            } else {
                                console.error('Error registering user:', error);
                            }
                        });
                }
            },
            validateForm() {
                this.errors = {};
                if (!this.formData.username) {
                    this.errors.username = 'Username is required';
                }
                if (!this.formData.name) {
                    this.errors.name = 'Name is required';
                }
                if (!this.formData.email) {
                    this.errors.email = 'Email is required';
                } else if (!this.isValidEmail(this.formData.email)) {
                    this.errors.email = 'Invalid email format';
                }
                if (!this.formData.password) {
                    this.errors.password = 'Password is required';
                } else if (!this.isValidPassword(this.formData.password)) {
                    this.errors.password = 'Password must be at least 8 characters long and contain at least one letter, one digit, and one \'@\' symbol';
                }
            },
            isValidEmail(email) {
                const emailRegex = /\S+@\S+\.\S+/;
                return emailRegex.test(email);
            },
            isValidPassword(password) {
                const passwordRegex = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@])[A-Za-z\d@]{8,}$/;
                return passwordRegex.test(password);
            }
        }
    }
</script>
<style scoped>
    .formcss {
         background-color: white;
    }
    .signup-form-container {
        position: absolute;
        top: 60%;
        left: 50%;
        transform: translate(-50%, -50%);
        width: 270px;
        padding: 30px;
         background-color: white;
        border-radius: 10px;
        /*box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);*/ /* Soft shadow */
    }

    .signup-form {
         background-color: white;
        margin-bottom: 20px;
    }
    .form-group label {
        margin-bottom: 8px; /* You can adjust the value as needed */
        margin-top: 8px;
    }

    .error {
        color: red;
        font-size: 0.875em;
        margin-top: 0.25em;
    }

    .btn-block {
        display: block;
        width: 100%; /* Full width buttons */
        margin: 10px 0; /* Spacing between buttons */
        padding: 10px;
        font-size: 16px;
        border-radius: 5px;
        cursor: pointer;
    }

    .btn-primary {
        background-color: #007bff;
        color: white;
        border: none;
    }

        .btn-primary:hover {
            background-color: #0056b3;
        }

    .btn-secondary {
        background-color: #6c757d;
        color: white;
        border: none;
    }

        .btn-secondary:hover {
            background-color: #5a6268;
        }
</style>

