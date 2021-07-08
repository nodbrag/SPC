<template>
    <div class="box_table dimensionDetail">

      <el-row class="warp">
        <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
        <el-table class="tableCss" :data="DimensionDetailList.items" border stripe style="width: 100%">
            <el-table-column  width="150px" v-for="item in DimensionDetailList.cols" :key="item" :label="item" >
                <el-table-column :prop="item" label=""></el-table-column>
            </el-table-column>
        </el-table>
        </el-col>
          <el-col :span="24" class="toolbar">
            <Pagination
              @handleCurrentChange="handleCurrentChange"
              @handleSizeChange="maxResultCountSelect"
              :page-size="maxResultCount"
              :page-sizes="pageSelectList"
              :total="totalCount">
            </Pagination>
          </el-col>

      </el-row>
    </div>
</template>
<script>
  import DimensionDetailView from '../../../View/DimensionDetailView';
  export default new DimensionDetailView()

</script>
<style>
.dimensionDetail .el-table td{
    border-bottom:1px solid #E5E5E5;
    border-right: 1px solid #E5E5E5;
    padding:3px 0;
    text-align: center
}
.dimensionDetail .el-table th{
    border-right:1px solid rgba(0,80,225,1);
    border-bottom:1px solid rgba(0,80,225,1);
    text-align: center
}
.dimensionDetail .el-table th.is-leaf{
    border-bottom:none;
    display: none
}
.dimensionDetail .el-table__header-wrapper{
    border-left:1px solid rgba(0,80,225,1);
    border-right:1px solid rgba(0,80,225,1);
}
.dimensionDetail .el-table__body-wrapper{
    border-left:1px solid #E5E5E5;
    border-right:1px solid #E5E5E5;
}
.dimensionDetail .el-table td .cell{
    line-height:14px;
    height:14px
}
@media screen and (min-width: 1500px) { 
  .tableCss {
    height:728px
  }
  .tableCss .el-table__body-wrapper{
    height: 95%;
    overflow: overlay;
  }
} 
@media screen and (max-width: 1366px) { 
  .tableCss {
    height:418px
  }
  .tableCss .el-table__body-wrapper{
    height: 92%;
    overflow: overlay;
  }
}
</style>
