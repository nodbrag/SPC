<template>
    <div class="box_pagination">
        <el-pagination
        @size-change="handleSizeChange"
        @current-change="handleCurrentChange"
        :page-sizes="pageSizes"
        :page-size="pageSize"
        layout="total, sizes, prev, pager, next, jumper"
        :total="total">
      </el-pagination>
    </div>
</template>

<script>
  export default {
    name: 'Pagination',
    props:['total','pageSize','pageSizes'],
    methods: {
      handleSizeChange(val) {
        console.log(val)
        this.$emit('handleSizeChange', val);
      },
      handleCurrentChange(val) {
        this.$emit('handleCurrentChange', val);
      }
    }
  }
</script>
<style lang="stylus" scope>
.box_pagination
    display: flex;
    flex-wrap: wrap;
    position:fixed;
    bottom:15px;
    right:40px
    .el-input--suffix
        border 0px
        height auto
</style>
