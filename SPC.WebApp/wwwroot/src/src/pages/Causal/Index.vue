<template>
    <div>
        <div class="top_tabbar">
            <ul>
                <router-link tag="li" to="/causal/list" class="active">工序列表</router-link>
            </ul>
        </div>
        <router-view></router-view>
    </div>
</template>
<style lang="stylus" scope>
@import '../../common/common.stylus'
</style>