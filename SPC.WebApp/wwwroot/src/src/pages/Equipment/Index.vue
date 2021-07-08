<template>
    <div>
        <div class="top_tabbar">
            <ul>
              <router-link tag="li" to="/equipment/EquipmentList" :class="{active:'/equipment/EquipmentList' === $route.path}">设备列表</router-link>
              <router-link tag="li" to="/equipment/EquipmentClass" :class="{active:'/equipment/EquipmentClass' === $route.path}">设备分类</router-link>
                <!-- <router-link tag="li" to="/dimension/summary" :class="{active:'/dimension/summary' === $route.path}">信息汇总</router-link> -->
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>
