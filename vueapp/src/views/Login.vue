<template>
    <div>
        <!-- Login form -->
        <div class="login-form-container">
            <div class="login-form">
                <h2 class="text-center mb-4">Log In</h2>
                <form @submit.prevent="submitForm">
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
                    <button type="submit" @click="closeOffcanvas" class="btn btn-primary btn-block">Log In</button>

                    <p>Not yet registered? <a href="#" class="signup-link" @click.prevent="$emit('show-signup')"> Signup here</a></p>
                </form>
            </div>
        </div>
    </div>
</template>

<script>
    import 'bootstrap/dist/css/bootstrap.min.css';
    import { Offcanvas } from 'bootstrap';
    import axios from 'axios';

    export default {
        name: 'LoginName',
        data() {
            return {
                formData: {
                    email: '',
                    password: ''
                },
                errors: {}
            };
        },
        methods: {
            closeOffcanvas() {
                // Close the offcanvas toggle
                const userDrawer = document.getElementById('userDrawer');
                if (userDrawer) {
                    const offcanvas = Offcanvas.getOrCreateInstance(userDrawer);
                    offcanvas.hide();

                }
            },
            submitForm() {
                this.validateForm();
                if (Object.keys(this.errors).length === 0) {
                    axios.post('https://localhost:7018/api/Authentication/login', this.formData)
                        .then(response => {
                            if (response && response.data && response.data.token) {
                                // Store the token in localStorage
                                localStorage.setItem('token', response.data.token);
                                // Redirect to a protected route or perform other actions
                                this.$router.push('/');
                            } else {
                                console.error('Empty response received from server');
                            }
                        })
                        .catch(error => {
                            if (error.response && error.response.data) {
                                console.error('Error logging in:', error.response.data);
                            } else {
                                console.error('Error logging in:', error);
                            }
                        });
                }
            },
            validateForm() {
                this.errors = {};
                if (!this.formData.email) {
                    this.errors.email = 'Email is required';
                }
                if (!this.formData.password) {
                    this.errors.password = 'Password is required';
                }
            }
        }
    }
</script>

<style scoped>
    .login-form-container {
        border-radius: 10px;
    }

    .login-form {
        margin-bottom: 20px;
    }

    .error {
        color: red;
        font-size: 0.875em;
        margin-top: 0.25em;
    }

    .btn-block {
        display: block;
        width: 100%;
        margin: 10px 0;
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
            background-color: white;;
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
