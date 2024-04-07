<template>
    <div v-if="loading" class="loading">
        Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
    </div>

    <div v-if="imageUrl">
        <img :src="imageUrl" :alt="imageUrl" />
    </div>
</template>

<script lang="ts">
    import { defineComponent } from 'vue';

    interface Data {
        loading: boolean,
        imageUrl: null | string
    }

    export default defineComponent({
        data(): Data {
            return {
                loading: false,
                imageUrl: null
            }
        },
        created() {
            this.fetchData();
        },
        watch: {
            '$route': 'fetchData'
        },
        methods: {
            fetchData(): void {
                this.imageUrl = null;
                this.loading = true;

                fetch('api/imagegenerator')
                    .then(r => r.blob())
                    .then(blob => {
                        this.imageUrl = URL.createObjectURL(blob);
                        this.loading = false;
                    });
            }
        },
    })
</script>