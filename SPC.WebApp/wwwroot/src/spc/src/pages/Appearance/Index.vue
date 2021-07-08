<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/appearance/list" :class="{active:'/appearance/list' === $route.path}">视觉数据列表</router-link>
                <div v-if="$route.path === '/appearance/detail'">
                    <li class="router-link-active active">数据详情</li>
                    <!-- <router-link tag="li" to="/appearance/detail" :class="{active:'/appearance/detail' === $route.path}">数据详情</router-link> -->
                </div>
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>
