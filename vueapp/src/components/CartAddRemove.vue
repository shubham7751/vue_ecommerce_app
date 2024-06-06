<template>
  <div v-if="localProduct" class="input-group plus-minus">
    <button class="btn btn-outline-secondary" :class="{ 'disabled': qty <= 1 || loading }" @click="addOrRemove(-1)" type="button">-</button>
    <input type="number" v-model="qty" disabled class="form-control form-control-sm" placeholder="" aria-label="Example text with button addon" aria-describedby="button-addon1">
    <button class="btn btn-outline-secondary" :class="{ 'disabled': qty >= 5 || loading }" @click="addOrRemove(1)" type="button">+</button>
  </div>
</template>

<script>
import { toast } from 'vue3-toastify';
import 'vue3-toastify/dist/index.css';

export default {
  name: 'CartAddRemove',
  props: ['product'],
  data() {
    return {
      localProduct: { ...this.product }, // Create a local copy of the prop
      qty: this.product.qty || 1, // Initialize qty with prop value or default to 1
      loading: false
    };
  },
  watch: {
    'localProduct.qty'(newVal) {
      this.qty = newVal;
    }
  },
  methods: {
    async addOrRemove(number) {
      if (this.loading) return;

      this.loading = true;

      if (number === 1 && this.qty < 10) {
        this.qty++;
        toast.success('Cart updated');
      } else if (number === -1 && this.qty > 1) {
        this.qty--;
        toast.success('Cart updated');
      } else {
        toast.warning('You reached the limit');
      }

      this.localProduct.qty = this.qty; // Update the local copy
      await this.$store.commit('updateCart', { product: this.localProduct });

      this.loading = false;
    }
  }
};
</script>

<style>
.plus-minus input {
  max-width: 50px;
}
</style>
