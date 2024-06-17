<template>
    <div style="margin-top:160px">
        <div class="border-toptext-black mb-2">
            <h1 class="display-6" style="text-align:center">Checkout</h1><hr/>
        </div>
        <div class="container mb-3">
            <div class="row">
                <div class="col-md-8">
                    <div class="card mb-3">
                        <div class="card-header">
                            <i class="bi bi-envelope"></i> Contact Info
                        </div>
                        <div class="card-body">
                            <div class="row g-3">
                                <div class="col-md-6">
                                    <input type="email"
                                           class="form-control"
                                           placeholder="Email Address"
                                           aria-label="Email Address" />
                                </div>
                                <div class="col-md-6">
                                    <input type="tel"
                                           class="form-control"
                                           placeholder="Mobile no"
                                           aria-label="Mobile no" />
                                </div>
                            </div>
                        </div>
                    </div>





                    <div className="card mb-3">
                        <div className="card-header">
                            <i className="bi bi-truck"></i> Shipping Infomation
                        </div>
                        <div className="card-body">
                            <div className="row g-3">
                                <div className="col-md-12">
                                    <input type="text"
                                           className="form-control"
                                           placeholder="Name"
                                           required />
                                </div>
                                <div className="col-md-6">
                                    <input type="text"
                                           className="form-control"
                                           placeholder="Addresss"
                                           required />
                                </div>
                                <div className="col-md-6">
                                    <input type="text"
                                           className="form-control"
                                           placeholder="Address 2 (Optional)" />
                                </div>
                                <div className="col-md-4">
                                    <select className="form-select" required>
                                        <option value>-- Country --</option>
                                        <option>United States</option>
                                    </select>
                                </div>
                                <div className="col-md-4">
                                    <select className="form-select" required>
                                        <option value>-- State --</option>
                                        <option>California</option>
                                    </select>
                                </div>
                                <div className="col-md-4">
                                    <input type="text"
                                           className="form-control"
                                           placeholder="Zip"
                                           required />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div className="card mb-3">
                        <div className="card-header">
                            <i className="bi bi-receipt"></i> Billing Infomation
                            <div className="form-check form-check-inline ms-3">
                                <input className="form-check-input"
                                       type="checkbox"
                                       defaultValue
                                       id="flexCheckDefault" />
                                <label className="form-check-label"
                                       htmlFor="flexCheckDefault">
                                    Same as Shipping Infomation
                                </label>
                            </div>
                        </div>
                        <div className="card-body">
                            <div className="row g-3">
                                <div className="col-md-12">
                                    <input type="text"
                                           className="form-control"
                                           placeholder="Name"
                                           required />
                                </div>
                                <div className="col-md-6">
                                    <input type="text"
                                           className="form-control"
                                           placeholder="Addresss"
                                           required />
                                </div>
                                <div className="col-md-6">
                                    <input type="text"
                                           className="form-control"
                                           placeholder="Address 2 (Optional)" />
                                </div>
                                <div className="col-md-4">
                                    <select className="form-select" required>
                                        <option value>-- Country --</option>
                                        <option>India</option>

                                    </select>
                                </div>
                                <div className="col-md-4">
                                    <select className="form-select" required>
                                        <option value>-- State --</option>
                                        <option>Maharashtra</option>
                                        <option>Karnatak</option>
                                        <option>Goa</option>
                                    </select>
                                </div>
                                <div className="col-md-4">
                                    <input type="text"
                                           className="form-control"
                                           placeholder="Zip"
                                           required />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div className="card mb-3 border-info">
                        <div className="card-header bg-info">
                            <i className="bi bi-credit-card-2-front"></i> Payment Method
                        </div>
                        <div className="card-body">
                            <div className="row g-3 mb-3 border-bottom">
                                <div className="col-md-6">
                                    <div className="form-check">
                                        <input id="credit"
                                               name="paymentMethod"
                                               type="radio"
                                               className="form-check-input"
                                               defaultChecked
                                               required />
                                        <label className="form-check-label" htmlFor="credit">
                                            Credit card
                                            <!--<img src="../../images/payment/cards.webp"
                                                 alt="..."
                                                 className="ms-3"
                                                 height={26} />-->
                                        </label>
                                    </div>
                                </div>
                                <div className="col-md-6">
                                    <div className="form-check">
                                        <input id="paypal"
                                               name="paymentMethod"
                                               type="radio"
                                               className="form-check-input"
                                               required />
                                        <label className="form-check-label" htmlFor="paypal">
                                            PayPal
                                            <!--<img src="../../images/payment/paypal_64.webp"
                                                 alt="..."
                                                 className="ms-3"
                                                 height={26} />-->
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div className="row g-3">
                                <div className="col-md-6">
                                    <input type="text"
                                           className="form-control"
                                           placeholder="Name on card" />
                                </div>
                                <div className="col-md-6">
                                    <input type="number"
                                           className="form-control"
                                           placeholder="Card number" />
                                </div>
                                <div className="col-md-4">
                                    <input type="number"
                                           className="form-control"
                                           placeholder="Expiration month" />
                                </div>
                                <div className="col-md-4">
                                    <input type="number"
                                           className="form-control"
                                           placeholder="Expiration year" />
                                </div>
                                <div className="col-md-4">
                                    <input type="number"
                                           className="form-control"
                                           placeholder="CVV" />
                                </div>
                            </div>
                        </div>
                        <div className="card-footer border-info d-grid">
                            <button type="button" className="btn btn-info">
                                Pay Now <strong>100</strong>
                            </button>
                        </div>
                    </div>
                    <!-- Rest of the checkout form goes here -->
                </div>
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-header">
                            <i class="bi bi-cart3"></i> Cart
                            <span class="badge bg-secondary float-end">4</span>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item d-flex justify-content-between lh-sm">
                                <div>
                                    <h6 class="my-0">Product name</h6>
                                    <small class="text-muted">Brief description</small>
                                </div>
                                <span class="text-muted">150</span>
                            </li>
                            <!-- Other list items -->
                            <li class="list-group-item d-flex justify-content-between">
                                <span>Total (Rupees)</span>
                                <strong>162</strong>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
  name: 'CheckOut',
};
</script>

<style scoped>
    /* Add scoped styles if needed */
</style>
