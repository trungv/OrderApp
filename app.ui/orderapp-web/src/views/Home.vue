<template>
  <div class="home">
    <Order />
  </div>
</template>

<script>
// @ is an alias to /src
import Order from "@/components/Order.vue";

export default {
  name: "home",
  components: {
    Order
  }
};
</script>
