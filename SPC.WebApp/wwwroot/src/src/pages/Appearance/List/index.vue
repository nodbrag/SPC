<template>
  <!--  <div>
       <div class="box_table">
           <TableToolBar :formData="formSearch"  @addModal="addModal(1)">
               <el-form-item slot="input">
                   <el-input
                       size="mini"
                       placeholder=""
                       v-model="formSearch.equipmentName">
                   </el-input>
               </el-form-item>
               <el-form-item slot="addModal" class="box_add">
                   <el-button type="primary" icon="el-icon-circle-plus-outline" size="mini" @click="addModal">添加</el-button>
               </el-form-item>
           </TableToolBar>
           <el-table
               :data="tableData.filter(data => !search || data.batch.toLowerCase().includes(search.toLowerCase()))"
               :default-sort = "{prop: 'number', order: 'descending'}"
               stripe
               style="width: 100%">
               <el-table-column
               label="编号"
               prop="equipmentID">
               </el-table-column>
               <el-table-column
               label="设备编号"
               prop="equipmentCode">
               </el-table-column>
               <el-table-column
               label="设备名称"
               prop="equipmentName">
               </el-table-column>
               <el-table-column
               label="设备类型"
               prop="equipmentType">
               </el-table-column>
               <el-table-column
               label="设备规格"
               prop="equipmentSpec">
               </el-table-column>
               <el-table-column
               label="投产时间"
               prop="productionDate">
               </el-table-column>
               <el-table-column
               label="生产厂商"
               prop="manufacturer">
               </el-table-column>
               <el-table-column
               label="生命周期"
               prop="lifeCircleYear">
               </el-table-column>
               <el-table-column
               label="描述"
               prop="memo">
               </el-table-column>
               <el-table-column
               label="操作">
                   <template slot-scope="scope">
                       <el-dropdown>
                           <span class="el-dropdown-link">
                               <i class="el-icon-caret-bottom el-icon--right"></i>   详细
                           </span>
                           <el-dropdown-menu slot="dropdown">
                               <el-dropdown-item><span @click="handleEdit(scope.$index, scope.row)">编辑</span></el-dropdown-item>
                               <el-dropdown-item><span  @click="handleDelete(scope.$index, scope.row)">删除</span></el-dropdown-item>
                           </el-dropdown-menu>
                       </el-dropdown>
                   </template>
               </el-table-column>
           </el-table>
           <Pagination></Pagination>
       </div>

       <addEditModal v-show="addVisible" :visible.sync="addVisible" :addOrEdit="addOrEdit" :formData="addOrEdit===1?{}:formModal" @handleModal="handleModal(arguments)" />
        <delModal v-show="delVisible" :visible.sync="delVisible" :rowId="rowId" @handleModalDel="handleModalDel(arguments)"></delModal>
    </div>-->
  <el-row class="warp">
    <el-col :span="24" class="warp-main box_table" v-loading="loading" element-loading-text="拼命加载中">
      <!--工具条-->
      <div class="table_tool">
        <div class="box_search">
          <el-form ref="form" :model="filter">
            <el-input v-model="filter.batchNo" placeholder="批次号" @keyup.enter.native="search" size="mini"></el-input>
            <el-date-picker v-model="filter.BeginDateTime" placeholder="开始时间" value-format="yyyy-MM-dd">
            </el-date-picker>
            <el-date-picker v-model="filter.EndDateTime" placeholder="结束时间" value-format="yyyy-MM-dd">
            </el-date-picker>
            <el-select v-model="filter.productId"  placeholder="请选择产品">
              <el-option
                v-for="item in productOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
            <el-select v-model="filter.equipmentId"  placeholder="请选择设备">
              <el-option
                v-for="item in equipmentOptions"
                :key="item.id"
                :label="item.name"
                :value="item.id">
              </el-option>
            </el-select>
            <el-button type="primary" icon="el-icon-search" size="mini" @click="search" >搜索</el-button>
          </el-form>
        </div>
      </div>
      <!--列表-->
      <el-table class="tableCss" :data="datalist" highlight-current-row @selection-change="selectInfos" stripe
                style="width: 100%;">
        <el-table-column type="index" width="60">
        </el-table-column>
        <el-table-column prop="batchNo" label="批次号">
        </el-table-column>
        <el-table-column prop="productName" label="产品名称" >
        </el-table-column>
        <el-table-column prop="equipmentName" label="视觉检测机">
        </el-table-column>
        <el-table-column prop="quantity" label="检测产品数量">
        </el-table-column>
        <el-table-column prop="beginDateTime" label="开始时间">
        </el-table-column>
        <el-table-column prop="endDateTime" label="结束时间">
        </el-table-column>
        <!--<el-table-column prop="description" label="描述">
        </el-table-column>-->
        <el-table-column label="操作" width="100">
          <template slot-scope="scope">
            <el-button size="small" @click="appearancejumpHtml(scope.row.batchNo)">详情</el-button>
          </template>
        </el-table-column>
      </el-table>
      <!--工具条-->
      <el-col :span="24" class="toolbar">
        <Pagination
          @handleCurrentChange="handleCurrentChange"
          @handleSizeChange="maxResultCountSelect"
          :page-size="maxResultCount"
          :page-sizes="pageSelectList"
          :total="totalCount">
        </Pagination>
      </el-col>
    </el-col>
  </el-row>
</template>
<script>
  import TaskView from '../../../View/TaskView';
  export default new TaskView()
</script>
<style lang="stylus" scope>
  @import '../../../common/common.stylus'
</style>
